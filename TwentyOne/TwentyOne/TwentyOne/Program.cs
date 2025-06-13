using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Casino;
using Casino.TwentyOne; //importing Casino namespace to use the Game class, added casino reference

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino"; //constant variable, cannot be changed  

            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank); //int.TryParse returns true if the input is a valid integer, and sets bank to that value
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");
            }

            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "yea" || answer == "ya")
            {
                Player player = new Player(playerName, bank);
                player.Id = Guid.NewGuid(); //Guids are ALWAYS unique
                using (StreamWriter file = new StreamWriter(@"C:\Users\conca\logs\logs.txt", true)) //true says To append some text to the file
                {
                    file.WriteLine(player.Id);
                }
                Game game = new TwentyOneGame(); //polymorphism
                game += player; //adds player to the game
                player.isActivelyPlaying = true; //sets player to actively playing
                while (player.isActivelyPlaying && player.Balance > 0) //checks if player wants to keep playing AND if he actually has enough money to play
                {
                    try
                    {
                        game.Play(); //calls the Play method from the TwentyOneGame class
                    }
                    catch(FraudException ex)
                    {
                        Console.WriteLine("Security! Kick this person out.");
                        UpdateDbWithException(ex); //updating db with exception details
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return; //if an error occurs, exit the program in void method, return ends program
                    }
                }
                game -= player; //removes player from the game
                Console.WriteLine("Thank you for playing!");
            }
            //if they say no, dont need else statement
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read(); //keeps console open until user presses enter
        }
        private static void UpdateDbWithException(Exception ex)
        {
            string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) 
                                VALUES (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //dealing with external db
                //Using parameterized queries helps protect from SQL injection attacks
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString(); //gets the type of the exception
                command.Parameters["@ExceptionMessage"].Value = ex.Message; //gets the message of the exception
                command.Parameters["@TimeStamp"].Value = DateTime.Now; //gets the current time

                connection.Open(); //opens the connection to the database
                command.ExecuteNonQuery(); //executes the command, which inserts the exception into the database
                connection.Close(); //closes the connection to the database
            }
        }
    }
}
