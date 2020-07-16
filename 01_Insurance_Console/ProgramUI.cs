using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Insurance;

namespace _01_Insurance_Console
{
    public class ProgramUI
    {
        private BadgeRepo _badgerepository = new BadgeRepo();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do ?\n" +
                    "1. View list of all Badges\n" +
                    "2. Add a new Badge\n" +
                    "3. Edit a Badge\n" +
                    "4. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddABadge();
                        Console.WriteLine("to continue press a key");
                        Console.ReadLine();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;

                    case "4":
                        keeprunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        break;
                }
            }
        }
        public void AddABadge()
        {
            var newBadge = new Badge();
            Console.WriteLine("What is the badge number?");
            var badgeNumber = int.Parse(Console.ReadLine());
            bool keepgoing = true;
            while (keepgoing)
            {
                Console.WriteLine("Enter a Door Number for current badge to have access");
                newBadge.DoorNumber = new List<string>();
                var userchoice = Console.ReadLine();
                newBadge.DoorNumber.Add(userchoice);
                Console.WriteLine("Are there more doors to add to current badge?\n"+"yes,no");
                var userInput = Console.ReadLine();
                if (userInput == "no")
                {
                    keepgoing = false;
                    _badgerepository.AddABadge(newBadge);
                    Console.WriteLine($"New badge has been add Badge Information is {newBadge.BadgeNumber}" + "Press any button to return to the main menu.");
                    Console.ReadKey();
                }
                else
                {
                    keepgoing = true;
                }
            }
        }
        public void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeholder = _badgerepository.ListAllBadges();
            foreach (KeyValuePair<int,List<string>> showbadge in badgeholder)
            {
                Console.WriteLine($"Badge ID is {showbadge.Key}\n");
                Console.WriteLine("Doors that can be access:");

                foreach (string listAllBadges in showbadge.Value)
                {
                    Console.WriteLine($"{showbadge}\n");
                }
            }
            Console.WriteLine("press any key to continue");
            Console.ReadLine();
        }
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Please enter the badgeID of the badge you wish to update.");
            var userInput = int.Parse(Console.ReadLine());
            var onebadge = _badgerepository.PullBadge(userInput);
            Console.WriteLine("This badge has access to the following doors: ");
            foreach (string value in onebadge.DoorNumber)
            {
                Console.WriteLine($"{value}");
            }
            var doorMiniMenu = true;
            while (doorMiniMenu)
            {
                Console.Clear();
                Console.WriteLine($"Badge: {onebadge} currently has access to the following doors: ");
                foreach (string door in onebadge.DoorNumber)
                {
                    Console.Write($"{door} - ");
                }
                Console.WriteLine("What would you like to do? \n" +
                    "1) Add new door. \n" +
                    "2) Remove door. \n" +
                    "3) Clear all doors from badge \n" +
                    "4) Finish updating badge \n" +
                    "Please enter either 1, 2 , or 3");
                var userReponse = Console.ReadLine();
                switch (userReponse)
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter the door you would like to add to this badge");
                            var newDoor = Console.ReadLine();
                            onebadge.DoorNumber.Add(newDoor);
                            Console.WriteLine($"Badge {onebadge.BadgeNumber} has been granted access to door {newDoor}.\n" +
                                $"Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please enter the door you would like removed from this badge.");
                            var removedDoor = Console.ReadLine();
                            _badgerepository.RemoveDoorFromBadge(onebadge.BadgeNumber, removedDoor);
                            Console.WriteLine($"Door ({removedDoor}) has been removed from the badge #{onebadge.BadgeNumber}. \n" +
                                $"Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Are you sure you want to remove all door access to this badge? \n" +"yes to continue or no to return");
                            string userChoice = Console.ReadLine().ToLower();
                            switch (userChoice)
                            {
                                case "yes":
                                    {
                                        _badgerepository.RemoveAllDoorsFromBadge(onebadge.BadgeNumber);
                                        Console.WriteLine("Door access for this badge has been removed. \n" +
                                            "Press any key to continue");
                                        Console.ReadKey();
                                        break;
                                    }
                                case "no":
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Enter either yes or no to choose an option.\n" + "Press any key to return..");
                                        Console.ReadKey();
                                        break;
                                    }
                            }

                            break;
                        }
                    case "4":
                        {
                            doorMiniMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid response. \n" +
                                "Please enter either 1, 2, or 3 \n" +
                                "Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                }

            }

            //Dictionary<int, List<string>> badgeholder = _badgerepository.ListAllBadges();
            //Console.WriteLine("Please enter the BadgeID you want to have removed");
            //int userInput = int.Parse(Console.ReadLine());
            //foreach (var badgeNumber in badgeholder)
            //{
            //    if (userInput == badgeNumber.Key)
            //    {
            //        _badgerepository.ListAllBadges(badgeNumber.Key);
            //        break;
            //    }
            //}
        }
        public void FeedBadges()
        {
            Badge badgeOne = new Badge(12345, new List<string> { "A1", "B1", "C1", "B2", "B3", "C2", "C3" });
            Badge badgeTwo = new Badge(22345, new List<string> { "B1", "B2", "B3" });
            Badge badgeThree = new Badge(32345, new List<string> { "C1", "C2", "C3" });

            _badgerepository.AddABadge(badgeOne);
            _badgerepository.AddABadge(badgeTwo);
            _badgerepository.AddABadge(badgeThree);
        }
    }
}
