using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdventureGame
{
    class ChapterOne
    {
        public static bool running = true;
        public static int KeystoneTotal = 5;
        public static bool ChOne = true;
        public static bool Cav1 = false;
        public static List<Weapon> ChamberOneDrop = new List<Weapon>();
        public static List<Item> ChamberOneItemDrop = new List<Item>();


        public static void Cavern1()
        {
            Console.Clear();
            Cav1 = true;
            Thread.Sleep(3000);
            Game.Narration("You stand at the center of the chamber, four passages surround you.");
            Game.Narration("One continues to the West, one to the North, and a third to the East.");
            Game.Narration("The fourth passageway leads to the the chamber in which you awoke.");
            DropPrint(ChamberOneDrop, ChamberOneItemDrop);
            Game.Break();
            Game.Narration("What do you do?");
            Game.PlayerChoice();
            if (Game.choice == "go west"){
                Cavern2();
            }else if(Game.choice == "go north")
            {
                Cavern3();
            }else if(Game.choice == "go east")
            {
                Cavern4();
            }
        }

        public static void Cavern2()
        {

        }

        public static void Cavern3()
        {

        }

        public static void Cavern4()
        {

        }
    }
}
