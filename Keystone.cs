using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace AdventureGame
{
    public class Keystone
    {
        public int Number { get; set; }
        public string Name = "gemstone fragment.";
        public string Color = "purple";

        public Keystone(int number)
        {
            this.Number = number;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string itemMessage = "You got a " + Color +" "+ Name + ".";
            foreach (char c in itemMessage)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Game.backpackKeystones.Add(this);
        }
    }
}
