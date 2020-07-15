using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge
{
    public class Menu
    {
        public string MealName { get; set; }
        public double Price { get; set; }
        public string MealNumber { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
              
        public Menu() { }
        public Menu(string mealname, double price, string description, List<string> ingredients, string mealNumber)
        {
            MealName = mealname;
            Price = price;
            Description = description;
            Ingredients = ingredients;
            MealNumber = mealNumber;
            

        }
    }
}
