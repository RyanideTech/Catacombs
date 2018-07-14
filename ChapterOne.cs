using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static AdventureGame.Game;

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
            Cav1 = true;
            while (Cav1 == true)
            {
                Console.Clear();
                Thread.Sleep(3000);
                Narration("You stand at the center of the chamber, four passages surround you.");
                Narration("One continues to the West, one to the North, and a third to the East.");
                Narration("The fourth passageway leads to the the chamber in which you awoke.");
                DropPrint(ChamberOneDrop, ChamberOneItemDrop);
                Break();
                Narration("What do you do?");
                PlayerChoice();
                if (choice == "go west")
                {
                    Cav1 = false;
                    Cavern2();
                }
                else if (choice == "go north")
                {
                    Cav1 = false;
                    Cavern3();
                }
                else if (choice == "go east")
                {
                    Cav1 = false;
                    Cavern4();
                }
                else if (choice == "go south")
                {
                    Narration("You begin to walk back towards the chamber in which you fell...");
                    Narration("As you enter the passage, a flash of energy knocks you to the ground.");
                    Break();
                    Narration("To escape the catacombs, you must navagate the chambers ahead.");
                }
                else if(choice == "open pack")
                {
                    Pack();
                }
                else
                {
                    Narration("You can't do this right now.");
                    Break();
                }
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

        public static void Cavern5()
        {

        }

        public static void Cavern6()
        {

        }

        public static void Cavern7()
        {

        }

        public static void Cavern8()
        {

        }

        public static void Cavern9()
        {

        }

        public static void Cavern10()
        {

        }

        public static void Cavern11()
        {

        }

        public static void Cavern12()
        {

        }

        public static void Cavern13()
        {

        }

        public static void Cavern14()
        {

        }

        public static void Cavern15()
        {

        }

        public static void Cavern16()
        {

        }

        public static void Cavern17()
        {

        }
    }
}
