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

        public Weapon(Bitmap img, string name, int damage) 
        {
            this.Img = img;
            this.Name = name;
            this.Damage = damage;
        }
    }

    //public class FWeapon : Weapons
    //{
    //    public Bitmap Img { get; set; }

    //    public FWeapon(Bitmap img) : base("Thunder Fury", 5)
    //    {
    //        Img = img;
    //    }

    //}

    //public class SWeapon : Weapons
    //{
    //    public Bitmap Img { get; set; }

    //    public SWeapon(Bitmap img) : base("Cave Crawler", 6)
    //    {
    //        Img = img;
    //    }

    //}

    //public class TWeapon : Weapons
    //{
    //    public Bitmap Img { get; set; }

    //    public TWeapon(Bitmap img) : base("WORLD DESTROYER", 7)
    //    {
    //        Img = img;
    //    }

    //}

    //public class RWeapon : Weapons
    //{
    //    public Bitmap Img { get; set; }

    //    public RWeapon(Bitmap img) : base("BOSS KILLER", 99999)
    //    {
    //        Img = img;
    //    }

    //}
}
