using Gold_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Console
{
    class ProgramUI
    {
        private Menurepository _menurepository = new Menurepository();
        public void Run()
        {

            RunMenu();
        }
        void RunMenu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do ?\n" +
                    "1. View list of all Meals\n" +
                    "2. Add a new Meal\n" +
                    "3. Remove a Meal\n" +
                    "4. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowMeals();
                        Console.WriteLine("to continue press a key");
                        Console.ReadLine();
                        break;
                    case "2":
                        AddMeal();
                        break;
                    case "3":
                        RemoveMeal();
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
        private void AddMeal()//adding to the menu
        {
            Menu newMeal = new Menu();

            Console.WriteLine("What is the Meal Number ?");
            string mealNumber = Console.ReadLine();

            Console.WriteLine("What is the Meal Name ?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What is the Meal Description ?");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are included in this meal ?\n" +
                "What is the first ingredient:");
            bool keepAdding = true;
            List<string> Ingredients = new List<string>();//might need to make it ListOfIngredients instead of just Ingredients
            while (keepAdding)
            {
                Ingredients.Add(Console.ReadLine());
                int numberOfIngredienets = Ingredients.Count;
                Console.WriteLine("Would you like to add another ingredient?\n" + "yes,no");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "yes":
                        Console.WriteLine($"Ingredient{numberOfIngredienets + 1}:");
                        break;

                    case "no":
                        keepAdding = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice Please enter yes or no");
                        break;
                }
            }
            Console.WriteLine("How much does this meal cost");
            double mealPrice = double.Parse(Console.ReadLine());

            newMeal.MealNumber = mealNumber;
            newMeal.MealName = mealName;
            newMeal.Ingredients = Ingredients;
            newMeal.Description = mealDescription;
            newMeal.Price = mealPrice;
            _menurepository.AddToMenu(newMeal);
            Console.WriteLine($"{newMeal.MealName} is now on the menu.\n press any key to continue");
            Console.ReadKey();
        }
        public void ShowMeals()
        {
            List<Menu> listOfMeals = _menurepository.GetMenuItems();
            foreach (Menu meal in listOfMeals)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber} | Meal Name: {meal.MealName} | Meal Price: ${meal.Price}\n");
            }
        }
        public void RemoveMeal()
        {
            Console.WriteLine("Enter a meal number to be removed");
            string userChoice = Console.ReadLine();
            Menu currentmenu = _menurepository.GetMealbyMealNumber(userChoice);
            Console.WriteLine($"{currentmenu.MealName}has been removed from menu. Press any key to continue.");
            _menurepository.RemoveItemFromMenu(currentmenu);
            Console.ReadKey();
        }
        void FeedMeals()
        {
            Menu mealOne = new Menu("Caesar Salad", 8d, "Fresh zesty crisp salad", new List<string> { "romaine lettuce", "croutons", "olive oil", "Parmesan cheese", "black pepper" }, "1");
            Menu mealTwo = new Menu("Steak Salad", 20d, "Juicy Savory Steak over crisp a crisp bold salad", new List<string> { "romaine lettuce, red onion, baby arugula, cherry tomatoes, gorgonzola, red wine vinaigrette, pound of steak" }, "2");
            Menu mealThree = new Menu("ShrimpCocktail", 12d, "Large shrimp with chilled cocktail sauce", new List<string> { "Large shrimp, kosher salt, cocktail sauce, lemon wedges" }, "3");
            _menurepository.AddToMenu(mealOne);
            _menurepository.AddToMenu(mealTwo);
            _menurepository.AddToMenu(mealThree);
        }
    }
}
