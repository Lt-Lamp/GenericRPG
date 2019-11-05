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
            "Noob", "BOSS GUN", "DESTROYER"
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

        //public static string RandDamage()
        //{
        //    return damage[rand.Next((int)damage)];
        //}

    }
}