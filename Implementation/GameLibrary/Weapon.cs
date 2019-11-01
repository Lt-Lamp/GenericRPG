using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Weapon : Weapons
    {
        public Bitmap Img { get; set; }


        public BaseWeapon(Bitmap img) : base("THE DESTROYER", 1)
        {
            Img = img;
        }
    }

}
