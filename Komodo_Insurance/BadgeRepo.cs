using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public class BadgeRepo
    {//use dictionary to hold values and key pairs
        public Dictionary<int, List<string>> _listofbadges = new Dictionary<int, List<string>>();
        public void AddABadge(Badge newBadge)
        {
            _listofbadges.Add(newBadge.BadgeNumber, newBadge.DoorNumber);
        }
        public Badge GetBadgeByBadgeNumber(int badgeNumber)
        {
            foreach (KeyValuePair<int, List<string>>currentBadge in _listofbadges) 
            {
                foreach (string door in currentBadge.Value)
                {
                    if (currentBadge.Key == badgeNumber)
                    {
                        Badge badge = new Badge(currentBadge.Key, currentBadge.Value);
                        return badge;
                    }
                }
            }return null;
        }
        public Dictionary<int, List<string>> ListAllBadges()
        {
            return _listofbadges;
        }
        public void RemoveAllDoorsFromBadge(int badgeId)
        {
            _listofbadges[badgeId].Clear();
        }
        public void RemoveDoorFromBadge(int badgeId, string roomNumber)
        {
            _listofbadges[badgeId].Remove(roomNumber);
        }
        public Badge PullBadge(int badgeId)
        {
            Badge badge = new Badge(badgeId, _listofbadges[badgeId]);
            return badge;

        }
    }
 }
