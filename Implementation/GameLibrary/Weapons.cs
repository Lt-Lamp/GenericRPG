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
        #region Constants
        private const float SIMPLEATTACK_RANDOM_AMT = 0.25f;
        #endregion

        public string Name { get; set; }
        public int Damage { get; set; }
        //public float Health { get; protected set; }

        private Random rand;

        public Weapons(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }


        public void SimpleWeaponAttack(Mortal receiver)
        {
            float baseDamage = Damage;
            receiver.Health -= (baseDamage * 1);

        }

        public void ManaWeaponAttack(Mortal receiver)
        {
            float baseDamage = Damage + 3;
            //receiver.Mana -= 5;
            receiver.Health -= (baseDamage * 1);
        }
    }
}
