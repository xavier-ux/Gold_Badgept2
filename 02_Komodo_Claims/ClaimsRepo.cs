using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
   public class ClaimsRepo
    {
        private Queue<Claim> _Claimsqueue = new Queue<Claim>();

        public Queue<Claim> ShowAllClaims()
        {
            return _Claimsqueue;
        }

        public void AddNewClaim(Claim claim)
        {
            _Claimsqueue.Enqueue(claim);
        }

        public Claim ShowNextInLine()
        {
            return _Claimsqueue.Peek();
        }

        public void RemoveClaimFromQueue()
        {
            _Claimsqueue.Dequeue();
        }
    }
}