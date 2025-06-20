using System;
using System.Collections.Generic;
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
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.WriteLine(exception.Id + " | ");
                    Console.WriteLine(exception.ExceptionType + " | ");
                    Console.WriteLine(exception.ExceptionMessage + " | ");
                    Console.WriteLine(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.Read();
                return;
            }

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank); //int.TryParse returns true if the input is a valid integer, and sets bank to that value
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals or text characters.");
            }
            if (bank <= 0)
            {
                Console.WriteLine("You must have money to play this game. Please come back when you have some money.");
                Console.ReadLine();
                return; //if bank is less than or equal to 0, exit the program
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
                        Console.WriteLine(ex.Message);
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TwentyOneGame;
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

        private static List<ExceptionEntity> ReadExceptions() //for admin to read exceptions from the database
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            string queryString = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions";
            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader(); //executes the command and returns a SqlDataReader object with ADO.Net
                
                while (reader.Read()) //loops thru each record you are getting back
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]); //converts the Id field to an integer
                    exception.ExceptionType = reader["ExceptionType"].ToString(); //converts the ExceptionType field to a string, because C# and SQL do not share data types
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString(); //converts the ExceptionMessage field to a string
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]); //converts the TimeStamp field to a DateTime object
                    Exceptions.Add(exception); //adds the exception to the list of exceptions
                }
                connection.Close();
            }
            return Exceptions;
        }
    }
}
