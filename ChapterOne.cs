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
        public static bool Cav2Puzzel = false;
        public static int KeystoneTotal = 5;
        public static bool ChOne = true;
        public static bool Cav1 = false;
        public static bool Cav2 = false;
        public static bool Cav3 = false;
        public static bool Cav4 = false;
        public static bool Cav5 = false;
        public static bool Cav6 = false;
        public static bool Cav7 = false;
        public static bool Cav8 = false;
        public static bool Cav9 = false;
        public static bool Cav10 = false;
        public static bool Cav11 = false;
        public static bool Cav12 = false;
        public static bool Cav13 = false;
        public static bool Cav14 = false;
        public static bool Cav15 = false;
        public static bool Cav16 = false;
        public static bool Cav17 = false;
        public static List<Weapon> ChamberOneDrop = new List<Weapon>();
        public static List<Item> ChamberOneItemDrop = new List<Item>();
        public static List<Weapon> ChamberTwoDrop = new List<Weapon>();
        public static List<Item> ChamberTwoItemDrop = new List<Item>();


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
                if (choice == "west")
                {
                    Cav1 = false;
                    Cavern2();
                }
                else if (choice == "north")
                {
                    Cav1 = false;
                    Cavern3();
                }
                else if (choice == "east")
                {
                    Cav1 = false;
                    Cavern4();
                }
                else if (choice == "south")
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
            Cav2 = true;
            while(Cav2 == true)
            {
                Console.Clear();
                Narration("WESTERN EDGE");
                Break();
                if(Cav2Puzzel == false)
                {
                    Narration("You are standing in a wide cavern, surrounded on all sides by rock.");
                    Narration("The only open passage leads back to the east, the way you came.");
                    Break();
                    Narration("The chamber is not well lit, however, you can almost make out the shape of two archways on the wall.");
                    Narration("It looks as though there may have been a passaage here, filled by a collapsing tunnel years ago.");
                    Break();
                    Narration("Between the two arches, you can see a pannel carved into the cavern wall.");
                    Narration("From where you are standing, you can't READ the inscription.");
                    Break();
                }
                else
                {
                    Narration("You are standing in a wide cavern, the rock wall has split open to reveal to more passages.");
                    Narration("One leads to the north-west, to other to the north-east.");
                    Narration("A third passage leads to the east.");
                    Break();
                }
                DropPrint(ChamberTwoDrop, ChamberTwoItemDrop);
                Break();
                Narration("What do you do?");
                PlayerChoice();
                if (Cav2Puzzel == false)
                {
                    if(choice == "read")
                    {
                        bool reading = true;
                        Console.WriteLine();
                        Console.WriteLine();
                        Narration("Stepping forward towards the ancient pannel, you notice an inscription.");
                        Narration("The words are written in a language you do not recognise.");
                        Break();
                        Narration("Reaching out coutiously towards the panel, you place your hand against the cold stone...");
                        Break();
                        Narration("Without warning, the stone of the pannel becomes intensly hot, nearly burning your hand.");
                        Narration("The characters of the inscription begin to glow...");
                        Break();
                        Narration("A voice echoes throughout the cavern, eminating from the air around you...");
                        EnemySpeak("* Hiss! * You who dares disturb this spirit, go no further!");
                        EnemySpeak("Those who harness my power may pass, those who refuse, shall pay a price in blood!");
                        Break();
                        EnemySpeak("My spirit has stood guard here since the birth of this prison.");
                        EnemySpeak("I live not, though I appear to, for I dance and breath.");
                        EnemySpeak("Believe not what you see, for I have no lungs or legs.");
                        Break();
                        Narration("As the voice echoes throughout the cavern, the characters on the panel begin to change shape...");
                        Narration("The carvings drip together to form letters...");
                        Break();
                        Narration("NAME THE GUARD AND YOU SHALL PASS. FAIL AND YOU SHALL PAY.");
                        Break();
                        while (reading == true) 
                        {
                            Narration("Who guards this passage?");
                            string riddle = "Spirit of ";
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (char c in riddle)
                            {
                                Console.Write(c);
                            }
                            choice = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            if (choice == "fire" || choice == "flame")
                            {
                                Narration("As you speak into the darkness, the inscription on the pannel begins to glow...");
                                Narration("You hear the spirit screeching in anger, the sound reverbarating throughout the cavern.");
                                Narration("The characters of the inscription slowly begin to melt as the glow intensifies.");
                                Narration("As you watch, the characters gather in a carving at the center of the pannel, condensing into a single mass.");
                                Break();
                                Narration("As the glow begins to fade, you see that the characters themselves have formed into a stone.");
                                Narration("You reach forward, removing the stone from its setting inside the pannel.");
                                Break();
                                Keystone Ch1K2 = new Keystone(2);
                                Break();
                                Narration("As you slip the fragment into your pack, the pannel itself seems to melt into the wall, disappearing.");
                                Cav2Puzzel = true;
                                Break();
                                Narration("As the pannel disappears, the two rock archways on the wall begin glow, illuminating ornate carvings on their rim.");
                                Narration("The glow intensifies, filling the center of the archway with light...");
                                Break();
                                Narration("As the glow fades away, you begin to see that two new passageways have formed in front of you.");
                                reading = false;
                                Thread.Sleep(4000);
                            }
                            else
                            {
                                EnemySpeak("* Hiss! * Foolish Upsider!");
                                EnemySpeak("You trespass within these caverns, you shall pay!");
                                Break();
                                Narration("As the voice echoes throughout the cavern, you suddenly feel a change in the air around you.");
                                Narration("The walls around you begin to radiate an intense heat.");
                                Narration("Quickly, the heat becomes unbearable, painfully continuing to grow in strength.");
                                Break();
                                Narration("With a flame like burst, you are blinded by a mass of energy as it is pulled from your body.");
                                Narration("You watch as the light is absorbed by the carving on the wall.");
                                Narration("As the energy disapears, the inscrition begins to glow in a fiery shade of red.");
                                Break();
                                EnemySpeak("You take 5 damage.");
                                Player.health -= 5;
                                EnemySpeak("Health Remaining: " + Player.health + "/" + Player.healthFull);
                                Break();
                                Narration("Try again?");
                                PlayerChoice();
                                bool check = false;
                                while (check == false)
                                {
                                    if (choice == "yes")
                                    {
                                        reading = true;
                                        check = true;
                                    }
                                    else if (choice == "no")
                                    {
                                        reading = false;
                                        check = true;
                                    }
                                    else
                                    {
                                        Narration("Would you like to try again? Answer yes or no.");
                                        check = false;
                                    }
                                }

                            }
                        }

                    }
                    else if(choice == "east")
                    {
                        Cav2 = false;
                        Cavern1();
                    }
                }
                else
                {
                    if(choice == "north-west")
                    {
                        Cav2 = false;
                        Cavern5();
                    }
                    else if(choice == "north-east")
                    {
                        Cav2 = false;
                        Cavern6();
                    }
                }
            }
        }

        public static void Cavern3()
        {
            Cav3 = true;
            while (Cav3 == true)
            {
                Console.Clear();
                Thread.Sleep(3000);

            }
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
