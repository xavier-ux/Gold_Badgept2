using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.AccessControl;
using Gold_Badge;

namespace Menurepotest
{
    [TestClass]

    public class menutest
    {
        [TestMethod]
        public void TestingAddToMenu()
        {
            _repo.AddToMenu(_menu);
            int expected = 1;
            int actual = _repo.GetMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestingRemoveMeal()
        {
            _repo.RemoveItemFromMenu(_menu);
            int expected = 0;
            int actual = _repo.GetMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        void TestingGetMealByNumber()
        {
            _repo.AddToMenu(_menu);
            string mealNumber = "3";
            string expected = "Shrimp Cocktail";
            Menu actual = _repo.GetMealbyMealNumber(mealNumber);
            Assert.AreEqual(expected, actual);
        }
        private Menurepository _repo;//bottom 3 lines might need to be a top if still giving errors
        private Menu _menu;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Menurepository();
            _menu = new Menu("ShrimpCocktail", 12d, "Large shrimp with chilled cocktail sauce", new List<string> { "Large shrimp, kosher salt, cocktail sauce, lemon wedges" }, "3");
        }
    }

}
