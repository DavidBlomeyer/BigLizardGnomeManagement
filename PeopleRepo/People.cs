using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRepo
{
    public enum AccessLevel
    {
        User = 1,           // look at basic stuff
        Manager = 2,        // look/create/update up to team/see log
        Admin = 3,          // all up to set access level 2
        SuperAdmin = 4      // all up to set access level 4
    }

    //POCO
    public class PeopleContent
    {
        // variable definition

        public int IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public bool PluralsightAccess { get; set; }
        //public int Team { get; set; }
        //public AccessLevel TypeOfAccess { get; set; }

        // zerod constructor

        public PeopleContent() { }

        // populated constructor
                //name          //args
        public PeopleContent(int idNumber, string firstName, string lastName, string fullName, string id, string password, bool pluralsightAccess)
        {   
            // property // value // "population"
            IDNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            ID = id;
            Password = password;
            PluralsightAccess = pluralsightAccess;
            //Team = team;
            //TypeOfAccess = accessLevel;
        }
    }
}
