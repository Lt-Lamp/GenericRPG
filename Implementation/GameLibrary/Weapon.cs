using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Weapon : Weapons
    {
        public Weapon() : base("THE DESTROYER", 2000)
        {
            Console.WriteLine("THE DESTROYER");
        }
    }
}
