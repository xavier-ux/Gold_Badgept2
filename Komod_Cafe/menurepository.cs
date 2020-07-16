using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge
{
    public class Menurepository
    {
        private List<Menu> _menus = new List<Menu>();
        //create new items
        public void AddToMenu(Menu newItems) 
        {
            _menus.Add(newItems);
        }
        public void RemoveItemFromMenu(Menu newItems)
        {
            _menus.Remove(newItems);
        }
        public Menu GetMealbyMealNumber(string mealNumber)
        {
            foreach (Menu meal in _menus)
            {
                if (meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }
            return null;
        }
        public List<Menu> GetMenuItems()
        {
            return _menus;
        }
    }
}

