using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace AdventureGame
{
    public class Weapon
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }

        public Weapon(string Name, int HP, int Damage, string Description)
        {
            this.Name = Name;
            this.HP = HP;
            this.Damage = Damage;
            this.Description = Description;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string itemMessage = "You got a " + Name + " with " + HP + " HP and a maximum damage of " + Damage + ".";
            foreach (char c in itemMessage)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Game.backpackWeapons.Insert(0, this);
        }
    }
}
