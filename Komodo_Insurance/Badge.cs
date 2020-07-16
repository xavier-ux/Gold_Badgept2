using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public class Badge
    {
        public int BadgeNumber { get; set;}
        public List<string> DoorNumber { get; set;}
        public Badge() { }
        public Badge(int badgeNumber, List<string> doorNumber)
        {
            BadgeNumber = badgeNumber;
            DoorNumber = doorNumber;
        }
        //public override string ToString()
        //{
        //    return $"{BadgeNumber}";
        //}
    }
}
