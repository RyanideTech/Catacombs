using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public string Weapon { get; set; }
        public int Damage { get; set; }
        public double Defense { get; set; }
        public double Critical { get; set; }

        public string Location { get; set; }

        public Enemy(string Name, int Health, string Weapon, int Damage, double defense, double critical, string Location)
        {
            this.Name = Name;
            this.Health = Health;
            this.Weapon = Weapon;
            this.Damage = Damage;
            this.Location = Location;
            this.Defense = defense;
            this.Critical = critical;
            Game.active.Add(this, Location);
        }
    }
}
