using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace Komodo
// {
    public class ProgramUI
    {
        private Dev_Repo _devRepo = new Dev_Repo();
        private Dev_Team_Repo _devTeamRepo = new Dev_Team_Repo();

        public void Run()
        {
            SeedDevList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Hello, Welcome to the Komodo Developer Management Program!\n" +
                "What would you like to do today?\n" +
                "1. Manage Individual Developers\n" +
                "2. Manage Developer Teams\n" +
                "3. Exit the Program\n" + 
                "Please enter a # 1-3");
                string input0 = Console.ReadLine();
                switch(input0)
                {
                    case "1":
                        ManageSingleDev();
                        break;
                    case "2":
                        ManageDevTeam();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void ManageSingleDev()
        {
            Console.Clear();
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Individual Developer Management:\n" +
                "1. Add a New Developer\n" +
                "2. View All Developers\n" +
                "3. Search Developer by ID\n" +
                "4. Update a Dev's Info\n" +
                "5. Delete a Developer\n" +
                "6. Exit to Previous Menu\n" +
                "Please enter a # 1-6\n");
                string input1 = Console.ReadLine();
                switch(input1)
                {
                    case "1":
                        AddNewDev();
                        break;
                    case "2":
                        ViewAllDevs();
                        break;
                    case "3":
                        ViewDevById();
                        break;
                    case "4":
                        UpdateDevInfo();
                        break;
                    case "5":
                        RemoveDev();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void AddNewDev()
        {
            Console.Clear();
            Developer newDev = new Developer();
            System.Console.WriteLine("Enter the Developer's First Name:");
            newDev.FirstName = Console.ReadLine();
            System.Console.WriteLine("Enter the Developer's Last Name:");
            newDev.LastName = Console.ReadLine();
            System.Console.WriteLine("Enter the Developer's Id Number:");
            string TempIdstring = Console.ReadLine();
            newDev.IdNumber = int.Parse(TempIdstring);
            System.Console.WriteLine("Does the Developer have Pluralsight Access?(y/n)");
            string PluralsightAccess = Console.ReadLine();
            if (PluralsightAccess == "y")
            {
                newDev.PluralAccess = true;
            } 
            else if (PluralsightAccess == "n")
            {
                newDev.PluralAccess = false;
            }
            else
            {
                System.Console.WriteLine("Please enter 'y' or 'n'");
            }
            _devRepo.AddDevToList(newDev);
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void ViewAllDevs()
        {
            Console.Clear();
            List<Developer> _listofDevs = _devRepo.GetDevList();
            foreach (Developer developer in _listofDevs)
            {
                System.Console.WriteLine($"First Name: {developer.FirstName} \n" +
                $"Last Name: {developer.LastName} \n" +
                $"Id Number: {developer.IdNumber} \n" +
                $"Has Pluralsight Access: {developer.PluralAccess} \n");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
        private void ViewDevById()
        {
            Console.Clear();
            System.Console.WriteLine("Enter the Developer's ID Number:");
            string input3 = Console.ReadLine();
            int input = int.Parse(input3);
            Developer idNumber = _devRepo.GetDevById(input);
            if (idNumber != null)
            {
                Console.Clear();
                System.Console.WriteLine($"First Name: {idNumber.FirstName} \n" +
                $"Last Name: {idNumber.LastName} \n" +
                $"Id Number: {idNumber.IdNumber} \n" +
                $"Has Pluralsight Access: {idNumber.PluralAccess} (Please enter true or false)\n");
            }
            else
            {
                System.Console.WriteLine("No developer was found by that ID.");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void UpdateDevInfo()
        {
            Console.Clear();
            ViewAllDevs();
            System.Console.WriteLine("Which Dev's info would you like to update?");
            int input4 = int.Parse(Console.ReadLine());
            Developer chosenOne = _devRepo.GetDevById(input4);
            System.Console.WriteLine("What would you like to change here? \n" +
            $"1. First Name: {chosenOne.FirstName} \n" +
            $"2. Last Name: {chosenOne.LastName} \n" +
            $"3. Id Number: {chosenOne.IdNumber} \n" +
            $"4. Has Pluralsight Access: {chosenOne.PluralAccess} \n" +
            "5. Cancel Update \n" +
            "Please enter the # you would like.");
            string input5 = Console.ReadLine();
            if (input5 != "5")
        {
            System.Console.WriteLine("Enter the New Information:");
            string updatedInfo = Console.ReadLine();
            switch (input5)
            {
                case "1":
                    chosenOne.FirstName = updatedInfo;
                    break;
                case "2":
                    chosenOne.LastName = updatedInfo;
                    break;
                case "3":
                int updateInfo = int.Parse(updatedInfo);
                    chosenOne.IdNumber = updateInfo;
                    break;
                case "4":
                    chosenOne.PluralAccess = bool.Parse(updatedInfo);
                    break;
            }
            bool wasUpdated = _devRepo.UpdateDevList(input4, chosenOne);
            if (wasUpdated)
            {
            System.Console.WriteLine("Content successfully updated!");
            }
            else
            {
            System.Console.WriteLine("Update did not work...");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        }
        private void RemoveDev()
        {
            Console.Clear();
            ViewAllDevs();
            System.Console.WriteLine("Enter the Id of the Dev you want to delete:");
            int input6 = int.Parse(Console.ReadLine());
            bool wasDeleted = _devRepo.RemoveDevFromList(input6);
            if (wasDeleted)
            {
                System.Console.WriteLine("Deletion Successful!");
            }
            else
            {
                System.Console.WriteLine("Deletion Failed...");
            }

        }
        private void ManageDevTeam()
        {
            Console.Clear();
            bool keepRunning = true;
            while(keepRunning)
            {
                System.Console.WriteLine("Developer Team Management:\n" +
                "1. Create a New Team\n" +
                "2. View Teams\n" +
                "3. Search for Team by TeamId\n" +
                "4. Update a Team's Info\n" +
                "5. Delete a team\n" +
                "6. Add a Developer to a Team\n" +
                "7. Remove a Developer from a Team\n" +
                "8. Exit to Previous Menu\n" +
                "Please enter a # 1-8\n");
                string input2 = Console.ReadLine();
                switch(input2)
                {
                    case "1":
                        CreateNewTeam();
                        break;
                    case "2":
                        ViewAllTeams();
                        break;
                    case "3":
                        ViewTeamById();
                        break;
                    case "4":
                        UpdateTeamInfo();
                        break;
                    case "5":
                        DeleteTeam();
                        break;
                    case "6":
                        AddDevToTeam();
                        break;
                    case "7":
                        RemoveDevFromTeam();
                        break;
                    case "8":
                        keepRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void CreateNewTeam()
        {
            Console.Clear();
            Dev_Team newTeam = new Dev_Team();
            System.Console.WriteLine("Enter the Team's Name:");
            newTeam.TeamName = Console.ReadLine();
            System.Console.WriteLine("Enter the Team's Id Number:");
            newTeam.TeamId = int.Parse(Console.ReadLine());
            _devTeamRepo.AddTeamToList(newTeam);
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void ViewAllTeams()
        {
            Console.Clear();
            List<Dev_Team> _listofTeams = _devTeamRepo.GetDevTeamList();
            foreach (Dev_Team dev_Team in _listofTeams)
            {
                System.Console.WriteLine($"\nTeam Name: {dev_Team.TeamName} \n" +
                $"Team Id Number: {dev_Team.TeamId} \n" +
                "Devs on Team:");
                PrintDevList(dev_Team);
            }
        } 
        private void ViewTeamById()
        {
            Console.Clear();
            
            System.Console.WriteLine("Enter the Team's ID Number:");
            string input1 = Console.ReadLine();
            int input = int.Parse(input1);
            Dev_Team teamId = _devTeamRepo.GetDevTeamById(input);
            if (teamId != null)
            {
                Console.Clear();
                System.Console.Write($"First Name: {teamId.TeamName} \n" +
                $"Team Id: {teamId.TeamId} \n");
                PrintDevList(teamId);
            }
            else
            {
                System.Console.WriteLine("No dev team was found by that ID.");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        } 
        private void UpdateTeamInfo()
        {
            Console.Clear();
            ViewAllTeams();
            System.Console.WriteLine("Which Team's info would you like to update? \n Enter the Id:");
            int input = int.Parse(Console.ReadLine());
            Dev_Team chosenTeam = _devTeamRepo.GetDevTeamById(input);
            System.Console.WriteLine("What would you like to change here? \n" +
            $"1. Team Name: {chosenTeam.TeamName} \n" +
            $"2. Team Id Number: {chosenTeam.TeamId} \n" +
            "3. Cancel Update \n" +
            "Please enter a number 1-3. \n");
            string input1 = Console.ReadLine();
            if (input1 != "3")
        {
            System.Console.WriteLine("Enter the New Information:");
            string updatedInfo = Console.ReadLine();
            switch (input1)
            {
                case "1":
                    chosenTeam.TeamName = updatedInfo;
                    break;
                case "2":
                    int newI = int.Parse(updatedInfo);
                    chosenTeam.TeamId = newI;
                    break;
            }
            bool wasUpdated = _devTeamRepo.UpdateDevTeamList(input, chosenTeam);
            if (wasUpdated)
            {
            System.Console.WriteLine("Content successfully updated!");
            }
            else
            {
            System.Console.WriteLine("Update did not work...");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        }
        private void DeleteTeam()
        {
            Console.Clear();
            ViewAllTeams();
            System.Console.WriteLine("Enter the Id of the Team you want to delete:");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(input);
            if (wasDeleted)
            {
                System.Console.WriteLine("Deletion Successful!");
            }
            else
            {
                System.Console.WriteLine("Deletion Failed...");
            }
            Console.Clear();
        } 
        private void AddDevToTeam()
        {
            Console.Clear();
            ViewAllTeams();
            System.Console.WriteLine("Which Team would you Like to Add a Dev to? \n" +
            "Please enter the team Id");
            int inputTeam = int.Parse(Console.ReadLine());
            if (_devTeamRepo.VerifyTeamExists(inputTeam))
            {
                Console.Clear();
                ViewAllDevs();
                System.Console.WriteLine("Enter the Developers Id that you would like to add:");
                int dev =int.Parse(Console.ReadLine());
                if (_devRepo.VerifyDevExists(dev))
                {
                    Dev_Team teamAdd = _devTeamRepo.GetDevTeamById(inputTeam);
                    Developer devAdd = _devRepo.GetDevById(dev);
                    teamAdd.AddDevToTeam(devAdd);
                }
                else
                {
                    System.Console.WriteLine("Dev with that ID does not exist.");
                }
                
            }
            else
            {
                System.Console.WriteLine("Team with that ID Doesn't Exist");
            }
            
            
        }
        private void RemoveDevFromTeam()
        {
            Console.Clear();
            ViewAllTeams();
            System.Console.WriteLine("Which Team would you Like to Delete a Dev from? \n" +
            "Please enter the team Id");
            int inputTeam = int.Parse(Console.ReadLine());
            if (_devTeamRepo.VerifyTeamExists(inputTeam))
            {
                Console.Clear();
                Dev_Team tempTeam = _devTeamRepo.GetDevTeamById(inputTeam);
                PrintDevList(tempTeam);
                System.Console.WriteLine("Enter the Developers Id that you would like to delete:");
                int dev =int.Parse(Console.ReadLine());
                if (_devRepo.VerifyDevExists(dev))
                {
                    Dev_Team teamDel = _devTeamRepo.GetDevTeamById(inputTeam);
                    Developer devDel = _devRepo.GetDevById(dev);
                    teamDel.RemoveDevFromTeam(devDel);
                }
                else
                {
                    System.Console.WriteLine("Dev with that ID does not exist.");
                }
                
            }
            else
            {
                System.Console.WriteLine("Team with that ID Doesn't Exist");
            }
        }
        private void SeedDevList()
        {
            Developer Brayden = new Developer("Brayden", "Bishop", 2834, true);
            Developer Bryce = new Developer("Bryce", "Bishop", 6378, false);
            Developer Alex = new Developer("Alex", "Penrose", 1639, true);
            Developer Kali = new Developer("Kali", "Miller", 0126, true);
            Developer Noah = new Developer("Noah", "Howell", 9335, true);
            Developer Mike = new Developer("John", "Michael Vore", 3474, true);
            Developer Blake = new Developer("Blake", "Levy", 7852, false);
            _devRepo.AddDevToList(Alex);
            _devRepo.AddDevToList(Blake);
            _devRepo.AddDevToList(Brayden);
            _devRepo.AddDevToList(Bryce);
            _devRepo.AddDevToList(Kali);
            _devRepo.AddDevToList(Mike);
            _devRepo.AddDevToList(Noah);

            Dev_Team red = new Dev_Team("Red", 1234);
            _devTeamRepo.AddTeamToList(red);
            red.DevsOnTeam.Add(Brayden);
            red.AddDevToTeam(Bryce);
            Dev_Team blue = new Dev_Team("Blue", 2345);
            _devTeamRepo.AddTeamToList(blue);
            blue.AddDevToTeam(Blake);
            blue.AddDevToTeam(Mike);
        }
        public string PrintDevList(Dev_Team teamName)
    {
        foreach (Developer dev in teamName.DevsOnTeam)
        {
            System.Console.WriteLine($"{dev.FirstName} {dev.LastName}\n Id :{dev.IdNumber}");
        }
        return null;
    }
    }

// }