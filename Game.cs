using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventureGame
{
    public static class Game
    {
        public static bool dropped = false;
        public static string choice;
        public static bool Ch1Restart = false;
        public static Random battleChance = new Random();
        public static List<Weapon> backpackWeapons = new List<Weapon>();
        public static List<Item> backpackItems = new List<Item>();
        public static List<Keystone> backpackKeystones = new List<Keystone>();
        public static Dictionary<Enemy, string> active = new Dictionary<Enemy, string>();
        public static Enemy c2Wraith = new Enemy("Wraith of the Shrouded Eye", 25, "staff", 7, 0.01, 0, "L1C2");
        public static bool Ch1 = false;
        public static bool KeystoneName = false;
        public static int Chamber;

        public static void DropPrint(List<Weapon> weapons, List<Item> items)
        {
            if (weapons.Count > 0 && items.Count > 0)
            {
                Console.WriteLine();
                Console.Write("A ");
                foreach (var c in items)
                {
                    if (items.Count == 1)
                    {
                        Console.Write(c.Name + ", ");
                    }
                    else if (c == items[0])
                    {
                        Console.Write(c.Name + ", ");
                    }
                    else
                    {
                        Console.Write("a " + c.Name + ", ");
                    }
                    Thread.Sleep(60);
                }
                foreach (var c in weapons)
                {
                    if (c == weapons[weapons.Count - 1])
                    {
                        Console.Write("and a " + c.Name);
                    }
                    else
                    {
                        Console.Write("a " + c.Name + ", ");
                    }
                    Thread.Sleep(60);
                }
                dropped = true;
            }
            else if (weapons.Count > 0)
            {
                Console.WriteLine();
                Console.Write("A ");
                foreach (var c in weapons)
                {
                    if (weapons.Count == 1)
                    {
                        Console.Write(c.Name);
                    }
                    else if (c == weapons[weapons.Count - 1])
                    {
                        Console.Write("and a " + c.Name);
                    }
                    else if (c == weapons[0])
                    {
                        Console.Write(c.Name + ", ");
                    }
                    else
                    {
                        Console.Write("a " + c.Name + ", ");
                    }
                    Thread.Sleep(60);
                }
                dropped = true;
            }
            else if (items.Count > 0)
            {
                Console.WriteLine();
                Console.Write("A ");
                foreach (var c in items)
                {
                    if (items.Count == 1)
                    {
                        Console.Write(c.Name);
                    }
                    else if (c == items[items.Count - 1])
                    {
                        Console.Write("and a " + c.Name);
                    }
                    else if (c == items[0])
                    {
                        Console.Write(c.Name + ", ");
                    }
                    else
                    {
                        Console.Write("a " + c.Name + ", ");
                    }
                    Thread.Sleep(60);
                }
                dropped = true;
            }
            else
            {
                dropped = false;
            }
            if (dropped == true && ((weapons.Count > 1 || items.Count > 1) || (weapons.Count == 1 && items.Count == 1)))
            {
                Console.Write(" lie on the ground.");
            }
            else if (dropped == true && ((weapons.Count == 1 && items.Count == 0) || (weapons.Count == 0 && items.Count == 1)))
            {
                Console.Write(" lies on the ground.");
            }
            Break();
            dropped = false;
        }

        public static void Pack()
        {
            Console.Clear();
            Narration("You remove your backpack from your shoulder and reach inside...");
            Narration("Inside are three pouches:");
            Console.WriteLine("Weapons.");
            Thread.Sleep(60);
            Console.WriteLine("Items.");
            Thread.Sleep(60);
            if (KeystoneName == true)
            {
                Console.WriteLine("Keystone fragments");
            }
            else
            {
                Console.WriteLine("??????????????????");
            }

            bool pack = true;
            while (pack == true)
            {
                Break();
                Narration("Which pouch do you open?");
                PlayerChoice();
                if (choice == "weapons")
                {
                    bool weapons = true;
                    while (weapons == true)
                    {

                        Console.Clear();
                        Console.WriteLine("Your Weapons:");
                        Console.WriteLine();
                        foreach (var c in backpackWeapons)
                        {
                            Console.WriteLine(c.Name + " --- " + c.Description + " --- " + c.HP + " remaining.");
                            Thread.Sleep(60);
                        }
                        Console.WriteLine();
                        Narration("Select a weapon or CLOSE the pouch:");
                        PlayerChoice();
                        if (backpackWeapons.Any(p => p.Name == choice))
                        {
                            int weaponIndex = backpackWeapons.FindIndex(p => p.Name == choice);
                            Narration("USE or DROP?");
                            PlayerChoice();
                            if (choice == "drop")
                            {
                                //Dynamically add drops for each cavern here
                                if (ChapterOne.ChOne == true && ChapterOne.Cav1 == true)
                                {
                                    ChapterOne.ChamberOneDrop.Add(backpackWeapons[weaponIndex]);
                                    Narration("You remove your " + backpackWeapons[weaponIndex].Name + " from your pack.");
                                    Narration("It will remain in this chamber if you return.");
                                    Break();
                                    backpackWeapons.Remove(backpackWeapons[weaponIndex]);
                                }
                                else if(ChapterOne.ChOne == true && ChapterOne.Cav2 == true)
                                {
                                    ChapterOne.ChamberTwoDrop.Add(backpackWeapons[weaponIndex]);
                                    Narration("You remove your " + backpackWeapons[weaponIndex].Name + " from your pack.");
                                    Narration("It will remain in this chamber if you return.");
                                }
                            }
                            else if (choice == "use")
                            {
                                int choiceIndex = backpackWeapons.FindIndex(p => p.Name == choice);
                                backpackWeapons.Insert(0, backpackWeapons[choiceIndex]);
                                backpackWeapons.Remove(backpackWeapons[choiceIndex + 1]);
                                Console.WriteLine();
                                Narration("You move your " + backpackWeapons[choiceIndex].Name + " to the top of your pack.");
                                Narration("It will come to you the next time you enter a battle");
                                Break();
                            }
                            else
                            {
                                Narration("You can't do this right now, please either USE or DROP your chosen weapon.");
                                Break();
                            }
                        }
                        else if (choice == "close")
                        {
                            weapons = false;
                            Narration("You close the pouch and begin looking through the rest of your pack.");
                            Break();
                            Console.Clear();
                        }
                        else
                        {
                            Narration("You can't do this right now, please either select a weapon or CLOSE the pouch.");
                            Break();
                        }
                    }
                }
                else if (choice == "items")
                {
                    bool items = true;
                    while (items == true)
                    {
                        Console.WriteLine("Your Items:");
                        Console.WriteLine();
                        foreach (var c in backpackItems)
                        {
                            Console.WriteLine(c.Name + " --- " + c.Description + " --- " + c.Effect);
                            Thread.Sleep(60);
                        }
                        Console.WriteLine();
                        Narration("Select a item or CLOSE the pouch:");
                        PlayerChoice();
                        if (backpackItems.Any(p => p.Name == choice))
                        {
                            int ItemIndex = backpackItems.FindIndex(p => p.Name == choice);
                            Narration("USE or DROP");
                            PlayerChoice();
                            if (choice == "drop")
                            {
                                //Dynamically add drop lists here
                                if (ChapterOne.ChOne == true && ChapterOne.Cav1 == true)
                                {
                                    ChapterOne.ChamberOneItemDrop.Add(backpackItems[ItemIndex]);
                                    Narration("You remove your " + backpackItems[ItemIndex].Name + " from your pack.");
                                    Narration("It will remain in this chamber if you return.");
                                    Break();
                                }
                                else if(ChapterOne.ChOne == true && ChapterOne.Cav2 == true)
                                {
                                    ChapterOne.ChamberTwoItemDrop.Add(backpackItems[ItemIndex]);
                                    Narration("You remove your " + backpackItems[ItemIndex].Name + " from your pack.");
                                    Narration("It will remain in this chamber if you return.");
                                    Break();
                                }
                            }
                            else if (choice == "use")
                            {
                                //Dynamically add item effect here
                            }
                            else
                            {
                                Narration("You can't do this right now, please either USE or DROP your chosen item.");
                                Break();
                            }
                        }
                        else if (choice == "close")
                        {
                            items = false;
                            Narration("You close the pouch and begin looking through the rest of your pack.");
                            Break();
                            Console.Clear();
                        }
                        else
                        {
                            Narration("You can't do this right now, please either select an item or CLOSE the pouch.");
                            Break();
                        }
                    }
                }
                else if (choice == "??????????????????" || choice == "?" || choice == "keystone fragments")
                {
                    if (KeystoneName == true)
                    {
                        Console.WriteLine("Your Keystone Fragments:");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("??????????????????");
                        Console.WriteLine();
                    }
                    foreach (var c in backpackKeystones)
                    {
                        Console.WriteLine(c.Color + c.Name);
                        Thread.Sleep(60);
                    }
                    if (KeystoneName == true)
                    {
                        Break();
                        //Dynamically Add Chapter Keystone totals here
                        if (ChapterOne.running == true)
                        {
                            Narration("You require " + (ChapterOne.KeystoneTotal - backpackKeystones.Count) + " to escape the cavern.");
                        }
                    }
                    Narration("CLOSE the pouch?");
                    PlayerChoice();
                }
                else if (choice == "close")
                {
                    pack = false;
                    Narration("You close the flap of your pack and sling it back over your shoulder.");
                    Break();
                    Console.Clear();
                }
                else
                {
                    Narration("You can't do that right now, please select a pouch or CLOSE your pack.");
                }
            }
        }
        public static void Dialogue(string line)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static void PlayerSpeak(string line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = Console.BufferWidth - line.Length;
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(60); ;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static void Narration(string line)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.WriteLine();
        }

        public static void EnemySpeak(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Break()
        {
            Console.WriteLine();
            Thread.Sleep(3000);
        }
        public static void PlayerChoice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            choice = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static void Battle(Enemy enemy)
        {
            Console.Clear();
            Narration("Drawing your " + backpackWeapons[0].Name + " and assuming a battle stance,");
            Narration("you come face to face with the " + enemy.Name + ".");
            Break();
            Narration("The " + enemy.Name + "'s " + enemy.Weapon + " materializes in a flash of light.");
            Break();
            bool finished = false;
            while (finished == false)
            {
                Narration("You have " + Player.health + " health remaining.");
                Narration("The " + enemy.Name + " has " + enemy.Health + " health remaining");
                if (backpackWeapons[0].HP <= 5)
                {
                    Narration("Your " + backpackWeapons[0].Name + " only has " + backpackWeapons[0].HP + " HP remaining.");
                    Narration("If your " + backpackWeapons[0] + "'s HP drops to 0, it will break.");
                }
                Break();
                Narration("What do you do?");
                PlayerChoice();
                if (choice == "attack")
                {
                    int enemyDefense = battleChance.Next(1, 10);
                    int critical = battleChance.Next(1, 10);
                    if (enemyDefense <= (enemy.Defense * 10))
                    {
                        int damage = battleChance.Next(1, backpackWeapons[0].Damage) / 2;
                        Narration("You attack the " + enemy.Name + " with your " + backpackWeapons[0].Name + ".");
                        Narration("The " + enemy.Name + " blocks your attack with its " + enemy.Weapon + ", your attack only does " + damage + " damage.");
                        if (backpackWeapons[0] != null)
                        {
                            Narration("The " + enemy.Weapon + " also deals " + enemyDefense * 100 + " damage to your " + backpackWeapons[0].Name + ".");
                            backpackWeapons[0].HP -= enemyDefense * 100;
                        }
                        if (backpackWeapons[0].HP <= 0 && backpackWeapons[1] != null)
                        {
                            Break();
                            Narration("Your " + backpackWeapons[0] + " has broken.");
                            backpackWeapons.Remove(backpackWeapons[0]);
                            Narration("You draw your " + backpackWeapons[0] + " from your bag and turn to the " + enemy.Name + ".");
                        }
                        Break();
                        enemy.Health -= damage;
                    }
                    else if (critical <= (Player.critical * 10))
                    {
                        int damage = battleChance.Next(1, backpackWeapons[0].Damage) * 2;
                        Narration("CRITICAL ATTACK! A beam of magical energy shoots forth from your " + backpackWeapons[0].Name + ". ");
                        Narration("The magic strikes the " + enemy.Name + " doing " + damage + " damage.");
                        Break();
                        enemy.Health -= damage;
                    }
                    else
                    {
                        int damage = battleChance.Next(1, backpackWeapons[0].Damage);
                        Narration("You attack the " + enemy.Name + " with your " + backpackWeapons[0].Name + " doing " + damage + " damage.");
                        enemy.Health -= damage;
                        Break();
                    }

                    if (enemy.Health <= 0)
                    {
                        Narration("With a final burst of magical energy from your " + backpackWeapons[0].Name + " the " + enemy.Name + " dissolves into a mist.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Break();
                        string success = "Success! The " + enemy.Name + " is defeated!";
                        finished = true;
                        foreach (char c in success)
                        {
                            Console.Write(c);
                            Thread.Sleep(60);
                        }
                        Break();
                        Console.Clear();
                    }

                }
                else if (choice == "switch")
                {
                    bool backpack = true;
                    while (backpack == true)
                    {
                        int counter = 0;
                        Console.WriteLine();
                        foreach (Weapon w in backpackWeapons)
                        {
                            counter += 1;
                            if (w == null)
                            {
                                continue;
                            }
                            Console.WriteLine(counter + ". {0}   -----   {1}", w.Name, w.Description);
                            Thread.Sleep(60);
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Choose your weapon:");
                        Console.Write("> ");
                        choice = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (backpackWeapons.Any(p => p.Name == choice))
                        {
                            int itemIndex = backpackWeapons.FindIndex(p => p.Name == choice);
                            var item = backpackWeapons[itemIndex];
                            backpackWeapons[itemIndex] = backpackWeapons[0];
                            backpackWeapons[0] = item;
                            Console.WriteLine();
                            Narration("You draw your " + backpackWeapons[0].Name + " from your bag and turn to the " + enemy.Name + ".");
                            Break();
                            Console.Clear();
                            backpack = false;
                        }
                        else
                        {
                            Console.WriteLine();
                            Narration("There is no weapon in your backpack with that name.");
                            Narration("Please enter the name of a weapon in your backpack.");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Narration("You haven't selected a valid option.");
                    Narration("To attack, simply tell your weapon to ATTACK.");
                    Break();
                }

                int playerDefense = battleChance.Next(1, 10);
                int enemyCritical = battleChance.Next(1, 10);
                if (playerDefense <= (Player.defense * 10))
                {
                    int damage = battleChance.Next(1, enemy.Damage) / 2;
                    Narration("As the " + enemy.Name + " attacks, you throw up your " + backpackWeapons[0].Name + " blocking the " + enemy.Weapon + ".");
                    Narration("Only " + damage + " damage is done.");
                    Break();
                    Player.health -= damage;
                }
                else if (enemyCritical <= (enemy.Critical * 10))
                {
                    int damage = battleChance.Next(1, enemy.Damage) * 2;
                    Narration("CRITICAL ATTACK! A wave of magic from the " + enemy.Name + "'s " + enemy.Weapon + " envelopes you.");
                    Narration("You feel a loss of strength as the energy rips " + damage + " health from your body.");
                    Break();
                    Player.health -= damage;
                }
                else
                {
                    int damage = battleChance.Next(1, enemy.Damage);
                    Narration("The " + enemy.Name + " attacks you with its " + enemy.Weapon + " doing " + damage + " damage.");
                    Player.health -= damage;
                    Break();
                }

                if (Player.health <= 0)
                {
                    Console.Clear();
                    Narration("A blinding white light shines from the " + enemy.Name + "'s " + enemy.Weapon + ", striking you.");
                    Narration("As the energy courses through your body, the world falls away around you.");
                    Narration("You collapse to the ground, unconcious.");
                    finished = true;
                    Break();
                    Console.Clear();
                    string gameOver = "Game over.";

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition((Console.WindowWidth - gameOver.Length) / 2, Console.WindowHeight / 2);
                    foreach (char c in gameOver)
                    {
                        Console.Write(c);
                        Thread.Sleep(100);

                    }
                    Console.SetCursorPosition((Console.WindowWidth - gameOver.Length) / 2, Console.WindowHeight - 5);
                    Narration("Continue from last checkpoint? [Y/n]");
                    bool restartQuerry = true;
                    while (restartQuerry == true)
                    {
                        string restart = Console.ReadLine().ToLower();
                        if (restart == "n")
                        {
                            restartQuerry = false;
                            Environment.Exit(0);
                        }
                        else if (restart == "y")
                        {
                            restartQuerry = false;
                            if (Ch1 == true)
                            {
                                Ch1Restart = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please select Y or N.");
                        }
                    }
                }
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        public static void StartGame()
        {
            //backpackWeapons[0] = null;
            Console.ForegroundColor = ConsoleColor.Gray;
            string Developer = "Seamonster Developement Presents...";
            Console.SetCursorPosition((Console.WindowWidth - Developer.Length) / 2, Console.WindowHeight / 2);
            foreach (char x in Developer)
            {
                Console.Write(x);
                Thread.Sleep(200);
            }
            Thread.Sleep(4000);
            Console.Clear();
            string GameTitle = @"










         ________  ________  _________  ________  ________  ________  _____ ______   ________  ________      
        |\   ____\|\   __  \|\___   ___\\   __  \|\   ____\|\   __  \|\   _ \  _   \|\   __  \|\   ____\     
        \ \  \___|\ \  \|\  \|___ \  \_\ \  \|\  \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \  \|\ /\ \  \___|_    
         \ \  \    \ \   __  \   \ \  \ \ \   __  \ \  \    \ \  \\\  \ \  \\|__| \  \ \   __  \ \_____  \   
          \ \  \____\ \  \ \  \   \ \  \ \ \  \ \  \ \  \____\ \  \\\  \ \  \    \ \  \ \  \|\  \|____|\  \  
           \ \_______\ \__\ \__\   \ \__\ \ \__\ \__\ \_______\ \_______\ \__\    \ \__\ \_______\____\_\  \ 
            \|_______|\|__|\|__|    \|__|  \|__|\|__|\|_______|\|_______|\|__|     \|__|\|_______|\_________\
                                                                                                 \|_________|";

            Console.WriteLine(GameTitle);
            string start = "Press enter to begin your adventure.";
            Console.SetCursorPosition((Console.WindowWidth - start.Length) / 2, Console.WindowHeight - 5);
            Console.WriteLine(start);
            Console.ReadKey();
            Console.Clear();
            string ProTitle = "PROLOGUE";
            Console.SetCursorPosition((Console.WindowWidth - ProTitle.Length) / 2, Console.WindowHeight / 2);
            Thread.Sleep(5000);
            foreach (char c in ProTitle)
            {
                Console.Write(c);
                Thread.Sleep(200);
            }
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(2000);
            Dialogue("...");
            Thread.Sleep(3000);
            Dialogue("Hello?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("A voice echoes through the darkness.");
            Narration("Opening your eyes, you see a bright light shining down from above you.");
            Narration("Its source is too far away to be seen.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("Who are you...?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("The voice speaks again.");
            Narration("You can't tell which direction it comes from.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("Who are you?");
            Dialogue("Why have you come to this place?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("Thinking as hard as you can, you realize you can't remember where you are or how you came to be here.");
            Narration("You speak out into the darkness, your voice echoing off of walls hidden by the veil of black.");
            Console.WriteLine();
            Thread.Sleep(3000);
            PlayerSpeak("I can't remember...");
            PlayerSpeak("What is this place?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("As you speak, a white mist begins to flow through the darkness around you.");
            Narration("Slowly, it begins to form into the shape of a being before your eyes.");
            Narration("...");
            Thread.Sleep(3000);
            Narration("Suddenly a hooded figure steps forth from the fog.");
            Narration("You cannot see its face, but a voice seems to reverberate within the empty space beneath its cloak.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("This is the Catacombs. A secret underworld, a long forgotten prison of forbidden magic.");
            Console.WriteLine();
            Thread.Sleep(3000);
            PlayerSpeak("What are you...?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("I am the gate keeper, holder of all keyes and guardian of the Catacombs.");
            Dialogue("I bear the burden of keeping watch over the entrance to our world.");
            Thread.Sleep(1000);
            Dialogue("You are human then?");
            Console.WriteLine();
            Thread.Sleep(3000);
            PlayerSpeak("Yes.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("Go forth with caution, non-magic one. Your kind are not well liked here,");
            Dialogue("for we were banished here centuries ago by humans who feared our magic.");
            Dialogue("You will not find many as kind as I am.");
            Dialogue("You must escape this place if you hope to survive.");
            Console.WriteLine();
            Thread.Sleep(3000);
            PlayerSpeak("How can I escape?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("There is only one way to leave the Catacombs...");
            Dialogue("You must seek a door sealed centuries ago by forces beyond imagine.");
            Dialogue("It is said that a warrior who controls this door will rule the Catacombs and wield all magic contained within.");
            Console.WriteLine();
            Thread.Sleep(3000);
            PlayerSpeak("Where will I find this door?");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("The door lies in the Cavern of Rune, beyond these tunnels.");
            Dialogue("I can guide you on the first leg of your journey, as far as the Cavern of Illusion.");
            Dialogue("Beyond there, you must make your own destiny.");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public static void Chapter1()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            bool Enterence;
            bool Cav2 = false;
            Ch1 = true;

            Console.WriteLine(@"






         ________  ___  ___  ________  ________  _________  _______   ________           _____     
        |\   ____\|\  \|\  \|\   __  \|\   __  \|\___   ___\\  ___ \ |\   __  \         / __  \    
        \ \  \___|\ \  \\\  \ \  \|\  \ \  \|\  \|___ \  \_\ \   __/|\ \  \|\  \       |\/_|\  \   
         \ \  \    \ \   __  \ \   __  \ \   ____\   \ \  \ \ \  \_|/_\ \   _  _\      \|/ \ \  \  
          \ \  \____\ \  \ \  \ \  \ \  \ \  \___|    \ \  \ \ \  \_|\ \ \  \\  \|          \ \  \ 
           \ \_______\ \__\ \__\ \__\ \__\ \__\        \ \__\ \ \_______\ \__\\ _\           \ \__\
            \|_______|\|__|\|__|\|__|\|__|\|__|         \|__|  \|_______|\|__|\|__|           \|__|
                                                                                           
                                                                                           
                                                                                           ");
            string Ch1Title = "Halls of Illusion";
            Console.SetCursorPosition((Console.WindowWidth - Ch1Title.Length) / 2, Console.WindowHeight - 5);
            Thread.Sleep(3000);
            Narration(Ch1Title);
            Thread.Sleep(5000);
            Console.Clear();
            Thread.Sleep(3000);
            Narration("The cavern around you grows dark as the Gatekeeper dissolves into a mist.");
            Narration("The only light you can see comes from far above you.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("The Gatekeeper's voice echoes in your mind...");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("You have much to learn, non-magic one.");
            Dialogue("To escape this place, you must first learn how to move about these halls...");
            Console.WriteLine();
            Thread.Sleep(3000);
            Narration("The Gatekeeper's glowing mist illuminates the enterence to a passage in front of you.");
            Narration("You can't see far enough down the tunnel to tell where it leads.");
            Console.WriteLine();
            Thread.Sleep(3000);
            Dialogue("To move through the Catacombs, you need only state which path you wish to follow.");
            Dialogue("Do this and the passage will make itself open to you.");
            Console.WriteLine();
            Narration("There is only one passageway illuminated by the glow.");
            Narration("It leads to the north...");
            Thread.Sleep(2000);
            Enterence = true;
            while (Enterence == true)
            {
                Thread.Sleep(3000);
                Thread.Sleep(3000);
                Narration("What do you do?");
                Console.WriteLine();
                PlayerChoice();

                if (choice == "north")
                {
                    Narration("Suddenly and without warning, hundreds of torches are illuminated.");
                    Narration("Light streams through the tunnel ahead.");
                    Console.WriteLine();
                    Thread.Sleep(3000);
                    Dialogue("Good...");
                    Dialogue("You have witnessed firsthand the magic which flows through these corridors.");
                    Dialogue("You must learn to wield it if you hope to escape.");
                    Console.WriteLine();
                    Thread.Sleep(3000);
                    Narration("Cautiously, you begin walking down the tunnel.");
                    Narration("It seems to go on forever...");
                    Narration("...");
                    Thread.Sleep(3000);
                    Narration("A sensation of dizziness comes over you as you walk down the hallway...");
                    Narration("The world seems to stretch and twist around you.");
                    Narration("The tunnel begins growing longer before your eyes.");
                    Narration("Unable to control your balance, you collapse to the ground.");
                    Console.WriteLine();
                    Thread.Sleep(3000);
                    Narration("Suddenly, the motion stops...");
                    Console.WriteLine();
                    Thread.Sleep(5000);
                    Enterence = false;
                    Cav2 = true;
                }
                else
                {
                    Narration("No passage leads in this direction.");
                    Narration("To open the passage, state the direction you wish to go.");
                    Narration("You stand in the dark cavern, staring down the long hallway.");
                    Cav2 = false;
                }
            }
            while (Cav2 == true)
            {
                Narration("Standing up from the ground, you see a pair of burning red eyes appear in the darkness...");
                Narration("With a burst of red light, a tattered and shredded purple gown surrounds the eyes.");
                Narration("A rasping voice growls through the hood...");
                Console.WriteLine();
                Thread.Sleep(3000);
                EnemySpeak("Pitiful human! Blind creature from above!");
                EnemySpeak("You should not have come!");
                EnemySpeak("At the hands of your prisoner, you will face death!");
                Console.WriteLine();
                Thread.Sleep(3000);
                Narration("Knocked to the ground by the creature's blast of fire, you speak to the apparition...");
                Console.WriteLine();
                Thread.Sleep(3000);
                PlayerSpeak("I mean no harm to you!");
                PlayerSpeak("I' only trying to leave this place!");
                Break();
                EnemySpeak("A wise decision...");
                EnemySpeak("Though you will never make it so far!");
                EnemySpeak("Bow before me, Wraith of the Shrouded Eye, maker of reality, unraveler of minds!");
                Break();
                Narration("With the creature's hiss, you begin to feel its presence inside your mind.");
                Narration("Once again the world begins to twist itself into impossible shapes...");
                Narration("Just as you begin to collapse, the sensation fades.");
                Narration("Looking up, you see the Gatekeeper's mist has made a wall between you and the Wraith.");
                Break();
                Dialogue("I cannot defend you for long...");
                Dialogue("You must defeat the creature if you hope to survive.");
                Break();
                Narration("A sword materializes in your hand, it faintly humms with magical energy.");
                Break();
                Weapon tutorialSword = new Weapon("Magical Sword", 10, 10, "A magically charged weapon given to you by the Gatekeeper.");
                Break();
                EnemySpeak("Ha! You believe you can defeat me with magic you know not how to control?");
                EnemySpeak("Do your worst puny being! I challange you for the honor of all chained magic!");
                Break();
                Narration("The creature produces a wave of magical energy.");
                Narration("You watch as the Gatekeeper is consumed by its glowing aura.");
                Break();
                EnemySpeak("Let us see how you fare without your precious guide!");
                Break();
                Thread.Sleep(2000);
                Narration("Faintly, you here the Gatekeeper's voice in your mind.");
                Break();
                Dialogue("To fight, you need only command your weapon to ATTACK the wraith.");
                Dialogue("Its magic will take control.");
                Dialogue("The best of luck to you, non-magic one.");
                Thread.Sleep(5000);
                Battle(c2Wraith);
                if (Ch1Restart == true)
                {
                    return;
                }
                Narration("As the Wraith breaks into dust, its voice screeches through the air around you...");
                Break();
                EnemySpeak("Wretched walker of the Earth! Foolish mortal!");
                EnemySpeak("With my defeat, you seal you own fate.");
                EnemySpeak("Though you may leave this chamber, you may not hope to surpass the cavern, ");
                EnemySpeak("for the Order of the Eye will not yield so easily as I have!");
                Break();
                Narration("The Wraith's words echo off of the rock walls as the being is consumed by the dust cloud.");
                Narration("As the creature disappears, a glowing fragment of a gem stone falls to the ground.");
                Break();
                Narration("Stepping forward, you pick up the shard.");
                Narration("It seems to vibrate in your hand as you examine it.");
                Break();
                Keystone Ch1K1 = new Keystone(1);
                Break();
                Narration("As you hold the vibrating stone, you once again hear the voice of the Gatekeeper.");
                Break();
                Dialogue("Congradulations, non-magic one.");
                Dialogue("You have taken your first step into the world of magic.");
                Dialogue("...");
                Break();
                Dialogue("There will be many more foes you must face on way, you must learn more if you hope to survive.");
                Break();
                Narration("Startled by the Gatekeeper's sudden reappearance, you speak out into the chamber...");
                Break();
                PlayerSpeak("What was that creature?");
                Break();
                Dialogue("The Wraith of the Shrouded Eye, an agent of the Order of the Eye.");
                Break();
                PlayerSpeak("The Order of the Eye...?");
                Break();
                Dialogue("An ancient society of magical beings.");
                Dialogue("It is said that together, they have ability to control the very fabric of reality.");
                Dialogue("They guard the Cavern of Illusion, the center of their power, and your only hope of escape.");
                Dialogue("You must defeat them if you wish to continue on your journey.");
                Break();
                PlayerSpeak("What do I have to do?");
                Break();
                Dialogue("These halls hold the key to you success.");
                Dialogue("You must strengthen yourself and your knowledge of magic.");
                Dialogue("Explore these caverns, and you will find the strength you seek.");
                Break();
                Narration("You prepare yourself for the long journey ahead.");
                Narration("...");
                Break();
                Narration("The Gatekeeper reaches out a claw-like hand from beneath its cloak.");
                Narration("The air around becomes energized, as if the room were filled with electricity...");
                Narration("As the sensation intensifies, you notice a shape has begun to form around the Gatekeeper's outstretched hand.");
                Break();
                Dialogue("Take this with you on your journey, it will help you to contain the magic of the items you find.");
                Break();
                Narration("As the Gatekeeper speaks, the energy form takes shape...");
                Break();
                Narration("The Gatekeeper hands you a pack, it has a single strap for your shoulder.");
                Break();
                Dialogue("If you ever wish to access your items, simply OPEN your PACK.");
                Dialogue("Your pack will contain whatever items you discover.");
                Break();
                Narration("You open your pack, placing the gemstone inside.");
                Narration("As you lift your sword, it collapses with a flash of blue light.");
                Narration("You place your now miniscule sword into the pack as well.");
                Break();
                Dialogue("When you enter into battle, whichever weapon is at the top of your pack will come to you.");
                Dialogue("You can reorder them by OPENing your PACK, opening the WEAPONS pouch, and commanding them to REORDER.");
                Dialogue("If your weapon breaks, the next highest weapon will take its place.");
                Dialogue("You can also DROP your weapons if you find yourself carrying too many.");
                Dialogue("Your dropped weapons will remain where you place them if you wish to come back later.");
                Break();
                Narration("You swing the pack over your shoulder.");
                Narration("Your determination to escape fills you with a new found strength.");
                Break();
                Dialogue("Go forth now, non-magic one.");
                Dialogue("Defeat the agents of the Order, and you will be free from these tunnels.");
                Break();
                Thread.Sleep(2000);
                Console.Clear();
                ChapterOne.Cavern1();

            }
        }
    }
}
