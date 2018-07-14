using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game.StartGame();
            do
            {
                Game.Chapter1();
            } while (Game.Ch1Restart == true);
        }
    }
}
