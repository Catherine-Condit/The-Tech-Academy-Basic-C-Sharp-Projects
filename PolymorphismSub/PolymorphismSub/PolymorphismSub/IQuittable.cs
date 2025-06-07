using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismSub
{
    public interface IQuittable
    {
        void Quit(); // Method to be implemented by any class that inherits this interface to provide a quitting functionality.
    }
}
