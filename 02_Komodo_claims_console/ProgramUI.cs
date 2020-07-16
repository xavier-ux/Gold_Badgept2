using _02_Komodo_Claims;
using _02_Komodo_claims_console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_claims_console
{
    public class ProgramUI
    {
        public ClaimsRepo _repo = new ClaimsRepo();
        Queue<Claim> _listOfClaims = new Queue<Claim>();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool keepgoing = true;
            while (keepgoing)
            {
                Console.Clear();
                Console.WriteLine("what would you like to do ?\n" +
                     "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            ShowClaims();
                            break;
                        }
                    case "2":
                        {
                            FileNextClaim();
                            break;
                        }
                    case "3":
                        {
                            AddNewClaim();
                            break;
                        }
                    case "4":
                        {
                            keepgoing = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please select option ");
                            Console.ReadKey();
                            break;
                        }
                }
                public void AddNewClaim()
                {
                    Claim newClaim = new Claim();
                    Console.WriteLine("Please enter the Claim ID: ");
                    newClaim.ClaimID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the number associated with the following Claim Types:\n" +
                        "1 - Car\n" +
                        "2 - House\n" +
                        "3 - Theft");
                    newClaim.ClaimType = (TypeOfClaim)(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Please enter the Claim Description: ");
                    newClaim.Description = (Console.ReadLine());

                    Console.WriteLine("Please enter the Claim Amount: ");
                    newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the Claim Incident Date. Use format: YYYY,MM,DD ");
                    newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Please enter the Claim Reported Date. Use format: YYYY,MM,DD ");
                    newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
                    string isValid;
                    if (_.(newClaim) == true)
                    {
                        isValid = "Valid";
                    }
                    else
                    {
                        isValid = "Not Valid";
                    }

                    _claimRepository.AddNewClaim(newClaim);
                    Console.WriteLine($"\nClaim ID: {newClaim.ClaimID}\n" +
                    $"Claim Type: {newClaim.ClaimType}\n" +
                    $"Claim Description: {newClaim.Description}\n" +
                    $"Incident Date: {newClaim.DateOfIncident}\n" +
                    $"Claim Date: {newClaim.DateOfClaim}\n" +
                    $"This claim is: {isValid}\n");
                }
            }
        }
