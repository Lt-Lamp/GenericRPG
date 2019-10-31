using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Weapons
    {
        public string Name { get; set; }
        public int Damage { get; set; }
            
        
       public Weapons(string name , int damage)
        {
            Name = name;
            Damage = damage;
        }

    }
}
