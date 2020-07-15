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

        //public bool AddToMenu(Menu newitems)
        //{
        //    int startingCount = _menus.Count;
        //    _menus.Add(newitems);
        //    bool wasAdded = (_menus.Count > startingCount);
        //    return wasAdded;
        //}
        ////read
        //public List<Menu> GetMenuItems()
        //{
        //    return _menus;
        //}
        //update method not needed yet
        //public bool UpdateMenu(string ogMenu, menu newmenu)
        //{
        //    menu oldmenu = GetItembyMealName(ogMenu);//should finds items on menu
        //    if (oldmenu != null)
        //    {
        //        oldmenu.NameOfMeal = newmenu.NameOfMeal;
        //        oldmenu.NameofIngredients = newmenu.NameofIngredients;
        //        oldmenu.DescriptionOfFood = newmenu.DescriptionOfFood;
        //        oldmenu.Price = newmenu.Price;
        //        oldmenu.MealNumber = newmenu.MealNumber;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //delete
//        public bool RemoveItemFromList(Menu newitems)
//        {
//            Menu newitems = GetItembyMealName(mealname);
//            if (newitems == null)
//            {
//                return false;
//            }
//            int initialCount = _menus.Count;
//            _menus.Remove(newitems);
//            if(initialCount > _menus.Count)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        //helper method
//        public Menu GetItembyMealName(string mealname)
//        {
//            foreach (Menu items in _menus)
//            {
//                if (items.MealName == mealname)
//                {
//                    return items;
//                }
//            }
//            return null;
//        }
//    }
//}
