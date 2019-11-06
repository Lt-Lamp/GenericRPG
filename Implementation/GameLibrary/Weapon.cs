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

        private static readonly Random rand = new Random();
        private static readonly List<string> names = new List<string>()
        {
            "Noob", "BOSS GUN", "THE DESTROYER"
        };

        private static readonly List<int> damage = new List<int>()
        {
            10, 15, 20, 25
        };

        public Weapon(Bitmap img) : base(RandName(), 4)
        {
            Img = img;
        }

        public static string RandName()
        {
            return names[rand.Next(names.Count)];
        }

    }

    public class FWeapon : Weapons
    {
        public Bitmap Img { get; set; }

        public FWeapon(Bitmap img) : base("Thunder Fury", 5)
        {
            Img = img;
        }

    }

    public class SWeapon : Weapons
    {
        public Bitmap Img { get; set; }

        public SWeapon(Bitmap img) : base("Cave Crawler", 6)
        {
            Img = img;
        }

    }

    public class TWeapon : Weapons
    {
        public Bitmap Img { get; set; }

        public TWeapon(Bitmap img) : base("WORLD DESTROYER", 7)
        {
            Img = img;
        }

    }

    public class RWeapon : Weapons
    {
        public Bitmap Img { get; set; }

        public RWeapon(Bitmap img) : base("BOSS KILLER", 99999)
        {
            Img = img;
        }

    }
}
