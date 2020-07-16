using System;
using Komodo_Insurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _01_Komodo_Test
{
    [TestClass]
    public class Komodo_UnitTest
    {
        [TestMethod]
        public void AddABadge_Test()
        {

        }
        
        private BadgeRepo _badgeRepository;
        private Badge _badge;
    
        [TestInitialize]
        public void Arrange()
        {
            _badgeRepository = new BadgeRepo();
            _badge = new Badge(100, new List<string> { "A1", "A2", "A3" });
        }

        [TestMethod]
        public void AddNewBadgeToListTest()
        {
            _badgeRepository.AddABadge(_badge);
            int expected = 1;
            int actual = _badgeRepository.ListAllBadges().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBadgeByBadgeIDTest()
        {
            _badgeRepository.AddABadge(_badge);
            Badge actual = _badgeRepository.GetBadgeByBadgeNumber(100);
            Assert.AreEqual(_badge.BadgeNumber, actual.BadgeNumber);
            Assert.AreEqual(_badge.DoorNumber, actual.DoorNumber);
        }
    }
}