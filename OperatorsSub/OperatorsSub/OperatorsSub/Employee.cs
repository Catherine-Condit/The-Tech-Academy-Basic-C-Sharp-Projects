using System;

namespace OperatorsSub
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //overloaded '==' operator
        //can compare two Employee objects ids using '=='
        public static bool operator== (Employee employee1, Employee employee2)
        {
            //if both are the same or both do not refer to any real Employee object, return true
            if (ReferenceEquals(employee1, employee2))
                return true;

            //if one (but not both) is null/does not refer to any real Employee object, return false
            if (employee1 is null || employee2 is null)
                return false;

            //compare the Ids of both Employee objects. if they are the same, we say they are equal
            return employee1.Id == employee2.Id;
        }

        //overloaded '!=' operator
        //can compare two Employee objects ids using '!='
        public static bool operator!= (Employee employee1, Employee employee2)
        {
            return !(employee1 == employee2); //use the == operator and reverse result
        }

    }
}
