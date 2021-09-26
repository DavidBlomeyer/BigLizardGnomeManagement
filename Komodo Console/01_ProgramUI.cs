using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Komodo_Console;
using PeopleRepo;
using TeamRepo;



namespace Komodo_Console
{
    // Startup
    class ProgramUI
    {
        // Load Needed Resources
        private PeopleContentRepo _contentPeopleRepo = new PeopleContentRepo();
        private TeamContentRepo _contentTeamRepo = new TeamContentRepo();

        // Run Start Menu - Enables seeding etc as needed
        public void Run()
        {
            SeedPeopleList();
            SeedTeamList();
            StartMenu();
        }

        // Start Menu
        private void StartMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello.  Welcome to the Komodo Insurance Developer Team Management App.");
                Console.WriteLine("Please Login to Get Started!");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Login\n" +
                                  "0. Exit");
                string inputA = Console.ReadLine();

                switch (inputA)
                {
                    case "1":
                        // Login
                        Login();
                        break;
                    case "0":
                        // Exit
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine("Please press any key to continue...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Login Function - Optional
        private void Login()
        {
            Console.Clear();
            Console.WriteLine("Please enter your user ID and Password.");
            Console.WriteLine("ID:");
            string ID = Console.ReadLine();


            Console.WriteLine("Password");
            string Password = Console.ReadLine();

            if (ID == "ID" && Password == "Password") // MOCKUP
            {
                // verb = check for person in personRepo

                // verb = check password for given person in personRepo

                MainMenu();
            }

            else
            {
                Console.WriteLine("Please enter a valid ID and password.");
            }


        }

        // Main Menu
        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Main Menu. Choose an option.");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Do Developer Stuff\n" +
                                  "2. Do Team Stuff\n" +
                                  "3. View the Log\n" +
                                  "0. Log Out");
                string inputA2 = Console.ReadLine();

                switch (inputA2)
                {
                    case "1":
                        // Do people stuff
                        PeopleMenu();
                        break;
                    case "2":
                        // Do team stuff
                        TeamMenu();
                        break;
                    case "3":
                        // View the Log
                        LogMenu();
                        break;
                    case "0":
                        // Log Out
                        StartMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // People Menu
        private void PeopleMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Developer Management Menu. Choose an option.");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Add a Developer\n" +
                                  "2. Roster of All Developers\n" +
                                  "3. Fully Report on a Single Developer by IDNumber\n" +
                                  "4. Display PluralSight Report\n" +
                                  "5. Update a Developer\n" +
                                  "6. Delete a Developer\n" +
                                  "0. Return to Previous Menu");
                string inputA3 = Console.ReadLine();

                switch (inputA3)
                {
                    case "1":
                        // Add a person
                        CreateNewPerson();
                        break;
                    case "2":
                        // Display All People Report
                        DisplayAllIDNumberFullNameIDContent();
                        break;
                    case "3":
                        // Display a Single Person by IDNumber
                        DisplayAPersonByIdNumber();
                        break;
                    case "4":
                        // Display PluralSight Report
                        DisplayPluralsightReport();
                        break;
                    case "5":
                        // Update a Person
                        UpdateExistingPerson();
                        break;
                    case "6":
                        // Delete a Person
                        DeleteExistingPerson();
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // People Menu Method Collection

        // Create new Person
        private void CreateNewPerson()
        {
            Console.Clear();
            PeopleContent newContent = new PeopleContent();

            //First name
            Console.WriteLine("Enter First Name of this Developer:");
            string firstName = Console.ReadLine();
            newContent.FirstName = firstName;

            //Last name
            Console.WriteLine("Enter Last Name of this Developer:");
            string lastName = Console.ReadLine();
            newContent.LastName = lastName;

            //Full name
            string fullName = $"{lastName}, {firstName}";
            newContent.FullName = fullName;

            //ID Number
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "These are all used IDNumbers.\n" +
                              "What IDNumber would you like to assign to this Developer?\n" +
                              "[An unused one is suggested.]:");
            string chosenNumber = Console.ReadLine();
            int idNumber = int.Parse(chosenNumber);
            newContent.IDNumber = idNumber;

            //ID
            string lastFour = lastName.Substring(0, lastName.Length > 4 ? 4 : lastName.Length);
            string id = $"{idNumber}{lastFour}";
            newContent.ID = id;

            //Password - Optional
            Console.WriteLine("What do you want to set for a password for this Developer?:\n" +
                              "[If your not sure, use Password]");
            newContent.Password = Console.ReadLine();

            //Pluralsight
            Console.WriteLine("Does the Developer have access to Pluralsight? (y/n):");
            string pluralAsString = Console.ReadLine().ToLower();

            if (pluralAsString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }

            //Team              ???
            //Console.WriteLine("Do you want to assign this Developer to a Team?:\n" +
            //                  "[If so, enter the team number (1, 2, 3, etc).  If not, enter (0)]");
            //string teamAsString = Console.ReadLine();
            //newContent.Team = int.Parse(teamAsString);

            //Access Level      ???
            //Console.WriteLine("What level of access do you want to assign to this Developer?:\n" +
            //                  "[1 = User, 2 = Manager 3 = Admin 4 = SuperAdmin]");
            //string accessAsString = Console.ReadLine();
            //int accessAsInt = int.Parse(accessAsString);
            //newContent.TypeOfAccess = (AccessLevel) accessAsInt;

            // Add the new Person to the content
            _contentPeopleRepo.AddPersonToList(newContent);
        }

        // Display all People
        private void DisplayAllIDNumberFullNameIDContent()
        {
            Console.Clear();
            List<PeopleContent> listOfContent = _contentPeopleRepo.GetPeopleList();

            foreach (PeopleContent content in listOfContent)
            {
                Console.WriteLine($"IDNumber: {content.IDNumber}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"ID: {content.ID}");
            }
        }

        // Display a single Person by IDNumber
        private void DisplayAPersonByIdNumber()
        {
            Console.Clear();
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you'd like to see:");

            string IDNumber = Console.ReadLine();
            int IDNumberParsed = int.Parse(IDNumber);


            PeopleContent content = _contentPeopleRepo.GetPeopleByIdNumber(IDNumberParsed);

            if (content != null)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"Pluralsight: {content.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No user with that ID.");
            }
        }

        // Display Pluralsight Report
        private void DisplayPluralsightReport()
        {
            Console.Clear();
            List<PeopleContent> listOfContent = _contentPeopleRepo.GetPeopleList();

            foreach (PeopleContent content in listOfContent)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"Has Pluralsight Access: {content.PluralsightAccess}");
            }
        }

        // Update Existing Person
        private void UpdateExistingPerson()
        {
            // Display People so a choice can be made without crying
            DisplayAllIDNumberFullNameIDContent();

            // Now that they can see, present choice
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you would like to update:");
            string oldIDNumber = Console.ReadLine();
            int oldIDNumberParsed = int.Parse(oldIDNumber);

            // Create "newcontent" obj
            PeopleContent newContent = new PeopleContent();

            //First name
            Console.WriteLine("Enter First Name of this Developer:");
            string newFirstName = Console.ReadLine();
            newContent.FirstName = newFirstName;

            //Last name
            Console.WriteLine("Enter Last Name of this Developer:");
            string newLastName = Console.ReadLine();
            newContent.LastName = newLastName;

            //Full name
            string newfullName = $"{newLastName}, {newFirstName}";
            newContent.FullName = newfullName;

            //ID Number
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "These are all used IDNumbers.\n" +
                              "What IDNumber would you like to assign to this Developer?\n" +
                              "[The one they have now is suggested.]:");
            string chosenNumber = Console.ReadLine();
            int idNumber = int.Parse(chosenNumber);
            newContent.IDNumber = idNumber;

            //ID
            string lastFour = newLastName.Substring(0, newLastName.Length > 4 ? 4 : newLastName.Length);
            string id = $"{idNumber}{lastFour}";
            newContent.ID = id;

            //Password
            Console.WriteLine("What do you want to set for a password for this Developer?:\n" +
                              "[If your not sure, default password is password]");
            newContent.Password = Console.ReadLine();

            //Pluralsight
            Console.WriteLine("Does this Developer have access to Pluralsight? (y/n):");
            string pluralAsString = Console.ReadLine().ToLower();

            if (pluralAsString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }

            //Team
            //Console.WriteLine("Do you want to assign this Developer to a Team?:\n" +
            //                  "[If so, enter the team number (1, 2, 3, etc).  If not, enter (0)]");
            //string teamAsString = Console.ReadLine();
            //newContent.Team = int.Parse(teamAsString);

            //Access Level
            //Console.WriteLine("What level of access do you want to assign to this Developer?:\n" +
            //                  "[1 = User, 2 = Manager 3 = Admin 4 = SuperAdmin]");
            //string accessAsString = Console.ReadLine();
            //int accessAsInt = int.Parse(accessAsString);
            //newContent.TypeOfAccess = (AccessLevel) accessAsInt;

            // Delete Old Content
            _contentPeopleRepo.RemoveContentFromList(oldIDNumberParsed);

            // Add New Content
            _contentPeopleRepo.AddPersonToList(newContent);

        }

        // Delete Existing Person
        private void DeleteExistingPerson()
        {
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you'd like to remove:");

            string input = Console.ReadLine();
            int parsedInput = int.Parse(input);

            bool wasDeleted = _contentPeopleRepo.RemoveContentFromList(parsedInput);

            if (wasDeleted)
            {
                Console.WriteLine($"{input} was deleted.");
            }
            else
            {
                Console.WriteLine($"{input} is not a valid ID.");
            }
        }


        // Seed People Method
        private void SeedPeopleList()
        {
            PeopleContent superadmin = new PeopleContent(0, "Alpha", "Omega", "Omega, Alpha", "0Omeg", "iamgodhere",
                true);
            PeopleContent greg = new PeopleContent(1, "Greg", "Wolfe", "Wolfe, Greg", "1Wolf", "password", true);


            _contentPeopleRepo.AddPersonToList(superadmin);
            _contentPeopleRepo.AddPersonToList(greg);
        }


        // Team Menu
        private void TeamMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Team Management Menu!");
                Console.WriteLine("Select a menu option:\n" +
                                  "1. Add a Team\n" +
                                  "2. Display All Teams\n" +
                                  "3. Display a Team Roster\n" +
                                  "4. Update a Team\n" +
                                  "5. Delete a Team\n" +
                                  "0. Return to Previous Menu");
                string inputA4 = Console.ReadLine();

                switch (inputA4)
                {
                    case "1":
                        // Add a Team
                        CreateNewTeam();
                        break;
                    case "2":
                        // Display All Teams
                        DisplayAllTeams();
                        break;
                    case "3":
                        // Display a Single Team in Depth
                        DisplaySingleTeam();
                        break;
                    case "4":
                        // Update a Team
                        UpdateATeam();
                        break;
                    case "5":
                        // Delete a team
                        DeleteATeam();
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Team Menu Method Collection

        // Create a New Team                        !!!!!!!!!
        private void CreateNewTeam()
        {
            Console.Clear();
            TeamContent newContent = new TeamContent();

            // Team Number
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What TeamNumber would you like to assign to this Team?:\n" + 
                              "[Please use an unused number.]");
            string tInput = Console.ReadLine();
            int parsedTInput = int.Parse(tInput);

            newContent.TeamNumber = parsedTInput;

            // Team Name
            DisplayAllTeams();
            Console.WriteLine("\n" + 
                              "What TeamName would you like to assign to this Team?:");
            string nInput = Console.ReadLine();

            newContent.TeamName = nInput;

            // Team Members
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" + 
                              $"Which Developer(s) would you like to add to the {nInput}s?:\n" + 
                              "[Format is IDNumbers separated by spaces 'IDNumber IDNumber etc' ie '1 2 3 4']\n" + 
                              "[If you don't want to add any, leave it blank.]\n" + 
                              "[If you want to add one, list one.]");

            //string fakeInput = "1 2 3 4 5 6 7 8 9 10 11 12";

            string input = Console.ReadLine();
            string[] pieces = input.Split(' ');
            List<int> intsList = new List<int>();
            int aNum;

            foreach (string s in pieces)
            { 
                if (Int32.TryParse(s, out aNum))
                        intsList.Add(aNum);
            }

            int[] magicArray = intsList.ToArray();

            newContent.TeamMembers = magicArray;

            // Make it so
            _contentTeamRepo.AddTeamToList(newContent);             // ????
        }

        // Display All Teams
        private void DisplayAllTeams()
        {
            Console.Clear();
            List<TeamContent> listOfContent = _contentTeamRepo.GetTeamList();

            foreach (TeamContent content in listOfContent)
            {
                Console.WriteLine($"Team Number: {content.TeamNumber}\n" +
                                  $"Team Name: {content.TeamName}");
            }
        }

        // Display a Single Team in Depth           !!!!!!!!!
        private void DisplaySingleTeam()
        {
            Console.Clear();
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "Enter the Team Number of the Team you'd like to see:");

            string teamNumber = Console.ReadLine();
            int teamNumberParsed = int.Parse(teamNumber);


            TeamContent teamContent = _contentTeamRepo.GetTeamByTeamNumber(teamNumberParsed);

            if (teamContent != null)
            {
                Console.WriteLine($"Team Number: {teamContent.TeamNumber}\n" +
                                  $"Team Name: {teamContent.TeamName}");

                for (int i = 0; i < teamContent.TeamMembers.Length; i++)
                {
                    PeopleContent peopleContent = _contentPeopleRepo.GetPeopleByIdNumber(teamContent.TeamMembers[i]);

                    if (peopleContent != null)
                    {
                        Console.WriteLine($"ID Number: {peopleContent.IDNumber}\n" +
                                          $"Full Name: {peopleContent.FullName}");
                    }

                    //// else for exceptions
                }
            }
            else
            {
                Console.WriteLine("No Team with that TeamNumber.");
            }
        }

        // Update a Team                        !!!!!!!!!2
        private void UpdateATeam()
        {
            // Display all teams
            DisplayAllTeams();

            // Ask for TN of team to update
            Console.WriteLine("\n" +
                              "Enter the TeamNumber of the Team you would like to update.:");

            // Get it
            string oldTeamNumber = Console.ReadLine();
            int oldTeamNumberParsed = int.Parse(oldTeamNumber);

            // Make new object
            TeamContent newContent = new TeamContent();

            // Team Number
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What TeamNumber would you like to assign to this Team?:\n" +
                              "[Please use an unused number.]");
            string tInput = Console.ReadLine();
            int parsedTInput = int.Parse(tInput);

            newContent.TeamNumber = parsedTInput;

            // Team Name
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What TeamName would you like to assign to this Team?:");
            string nInput = Console.ReadLine();

            newContent.TeamName = nInput;

            // Team Members
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              $"Which Developer(s) would you like to add to the {nInput}s?:\n" + 
                              "[Format is (IDNumber, IDNumber, etc) ie (1, 2, 3, 4)]");
            
                    // ???

            // delete old data
            _contentTeamRepo.RemoveTeamFromList(oldTeamNumberParsed);

            // add new data
            _contentTeamRepo.AddTeamToList(newContent);

            Console.WriteLine("Team Updated. Press any key to continue.");
            Console.ReadLine();
        }

        // Delete a Team
        private void DeleteATeam()
        {
            // show all teams
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What Team would you like to remove?");

            // get team number
            string input = Console.ReadLine();
            int parsedInput = int.Parse(input);

            // the stuff
            bool wasDeleted = _contentTeamRepo.RemoveTeamFromList(parsedInput);

            // If the content was deleted, say so 
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }

            // Otherwise state it could not be deleted
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }

        // Seed Team Method
        public void SeedTeamList()
        {

            int[] aJetsRoster = {1};
            int[] aSharksRoster = {2};

            TeamContent Jets = new TeamContent(1, "Jets", aJetsRoster);
            TeamContent Sharks = new TeamContent(2, "Sharks", aSharksRoster);


            _contentTeamRepo.AddTeamToList(Jets);
            _contentTeamRepo.AddTeamToList(Sharks);
        }

        // Log Menu                     - Optional
        private void LogMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Log. Choose an option.");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Display Recent Log\n" +
                                  "2. Display Entire Log\n" +
                                  "3. Display Log for a Person\n" +
                                  "4. Display Log for an Action\n" +
                                  "0. Return to Previous Menu");
                string inputA5 = Console.ReadLine();

                switch (inputA5)
                {
                    case "1":
                        // Display Recent Log
                        // verb
                        break;
                    case "2":
                        // Display Entire Log
                        // verb
                        break;
                    case "3":
                        // Display Log for a Person
                        // verb
                        break;
                    case "4":
                        // Display Log for an Action
                        // verb
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }
            }

            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Log Menu Method Collection



    }
}