using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Interfaces
{
    interface IWalkAway //naming convention: interfaces start with I captialized
    {
        //An interface is similar to an abstract class in that there are no implementation details.

        //rule: must be a way that player can stand up and walk away with his money
        //you can only ineherit one base class, but can inherit as many interfaces as you want
        void WalkAway(Player player); //everything is public in an interface
    }
}
