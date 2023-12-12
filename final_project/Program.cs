﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //read file. probably need??
using System.Xml;
using System.Threading; //sleep
using final_project.item_folder;
using final_project.npc_folder;
using System.Data.SqlTypes;
using System.Net.Security;
using System.Security;

namespace final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string player_name;
            int file_line_number = 0;

            string[] possible_melee_weapons = { "rusted sword", "iron sword", "steal sword", "mace", "iron spear" };
            string[] possible_melee_weapons_description = { "A simple sword. It has seen many slain enemies and showing it's age", "A sturdy well balanced sword", "A powerful sword, enemies before you stand no chace", "A brutal crushing device, few can withstand it's power", "A pole with a iron tip on the end that excells at slaying those before it" };

            string[] possible_range_weapons = { "bow", "long bow", "crossbow", "slingshot" };
            string[] possible_range_weapons_description = { "A regular bow", "A long bow much more poweful then a regular bow", "A crossbow allowing you accurate shots with powerful damage", "A simple slingshot, best as a toy for children" };

            string[] possible_armor = { "old leather armor", "plate armor", "chainmail armor", "Elven Silks" };
            string[] possible_armor_description = { "Worn out leather armor. It has defened it's wearer through many battles", "Heavy armor that offers the most protectoin", "stab resistant armor but weighs it's wearer down", "Light armor made to protect elven diplomats from attackers" };

            string[] equipment_array = new string[8];   //creates an array with 8 slots. Why does C# do this so weirdly. 

            string[] enemy_sword_types = { "Weak Sword", "Sword", "Strong Sword" };
            string[] enemy_range_types = { "Bow", "Crossbow", "Slingshot" };

            #region player_name get
            Console.Write("WELCOME! Please enter your name player: ");
            player_name = Console.ReadLine();

            //makes sure user has a name not whitespace
            while (string.IsNullOrWhiteSpace(player_name)) //github post :)
            {
                Console.Write("Please enter your name: ");
                player_name = Console.ReadLine();
            }
            
            var player = new player(player_name);

            #endregion playe_name get


            #region fake questionaire
         /*   

            int user_input_fake_questions = 5;
            int multiple_choice_fake_questions = 8;

            string fake_question_answer = "";

            var fake_questions = new StreamReader("fake_questionaire.txt");

       
            Console.WriteLine(fake_questions.ReadLine());

            //first 5 questions as they're focused on any user input (trains user for user input)
            while (file_line_number < user_input_fake_questions) //github
            {
                Console.Write(fake_questions.ReadLine());
                Console.ReadLine();
                file_line_number++;
            }

            //next 3 questions to focus on multiple choice (trains user for multiple choice)
            while (file_line_number < multiple_choice_fake_questions)
            {
                Console.WriteLine(fake_questions.ReadLine()); //gets question
                Console.Write(fake_questions.ReadLine()); //answer choices
                fake_question_answer = Console.ReadLine().ToUpper();
                while (fake_question_answer != "A" && fake_question_answer != "B" && fake_question_answer != "C") //if player not enter a valid answer
                {
                    Console.WriteLine("Enter a valid choice");
                    fake_question_answer = Console.ReadLine().ToUpper();
                }
                file_line_number++;
            }

            file_line_number = 0; //resets file_line_number for future files
            fake_questions.Close(); //close file because it's what you're supposed to do. 
            */
            #endregion fake questionaire


            #region shift to true game
            
            /*
            var shifting_game = new StreamReader("shift_true_game.txt");

            Console.WriteLine("\n\n");

            Console.ForegroundColor = ConsoleColor.Green;
            while (!shifting_game.EndOfStream)
            {
                Thread.Sleep(2500);
                Console.WriteLine(shifting_game.ReadLine());
            }
            */
            #endregion shift to true game


            #region setting up character
            string player_class_get;

            /*
            Thread.Sleep(5000);
            Console.Clear();

            Console.WriteLine("Let me set everything up....");
            Thread.Sleep(4000);
            Console.WriteLine("Ok... this is taking a bit longer then I thought...");
            Thread.Sleep(1500);
            Console.WriteLine("Almost done I promise");
            Thread.Sleep(1599);
            Console.WriteLine("Just gotta do one more thing");
            Thread.Sleep(2500);
            Console.WriteLine("Ah there we go. Now everything is ready\n\n");
            */
            Console.ForegroundColor = ConsoleColor.White;
            

            Console.WriteLine("Choose your class: ");
            Console.WriteLine("A: Fighter");
            Console.WriteLine("\tYou have exeptional combat training at the cost of stealth");
            Console.WriteLine("B: Infiltrator");
            Console.WriteLine("\tYou are much harder to detect at the cost of combat training");
            Console.WriteLine("C: Hero");
            Console.WriteLine("\tYou have no expertise, but no downsides");

            
            player_class_get = Console.ReadLine().ToLower();
            while (player_class_get != "fighter" && player_class_get != "a" && player_class_get != "infiltrator" && player_class_get != "b" && player_class_get != "hero" && player_class_get != "c")
            {
                Console.WriteLine("Choose a valid class, Fighter, Infiltrator, or Hero");
                player_class_get = Console.ReadLine().ToLower();
            }

            switch (player_class_get) //switch to avoid if-else ladder
            {
                case "a":
                    player_class_get = "fighter";
                    break;

                case "b":
                    player_class_get = "infiltrator";
                    break;

                case "c":
                    player_class_get = "hero";
                    break;

                default:
                    break;
            }

            player.player_class = player_class_get; //sets player_class to the class the user wants to use


            switch (player.player_class) //initializes class stats
            {
                case "fighter":
                    player.player_health = 11;
                    player.player_defense = 10;
                    player.player_strength = 12;
                    player.player_speed = 7;
                    player.player_stealth = 5;
                    player.player_charisma = 6;
                    player.class_definition = "You're fighter from birth, you have increased health, defence, and strength at the cost of your speed, stealth, and charisma";
                    break;

                case "infiltrator":
                    player.player_health = 9;
                    player.player_defense = 8;
                    player.player_strength = 7;
                    player.player_speed = 10;
                    player.player_stealth = 12;
                    player.player_charisma = 8;
                    player.class_definition = "Being one with the shadows you have increased speed and stealth at the cost of your health, defense, and strength";
                    break;

                case "hero":
                    player.player_health = 10;
                    player.player_defense = 9;
                    player.player_strength = 8;
                    player.player_speed = 9;
                    player.player_stealth = 8;
                    player.player_charisma = 10;
                    player.class_definition = "Being a hero of the city you have a natrual gift of charisma, though no other bonuses or setbacks to your other stats";
                    break;
            }
            #endregion setting up character


            #region setting initial items

            var player_weapon = new weapon(possible_melee_weapons[0], possible_armor_description[0]);
            player_weapon.damage = random.Next(4, 7);
            player_weapon.isRange = false;
            player_weapon.crit_chance = 0;
            player_weapon.crit_amount = 0;

            var player_armor = new armor(possible_armor[0], possible_armor_description[0]);
            player_armor.defence_amount = random.Next(2, 4);
            player_armor.isHeavy = false;
            player_armor.crit_defence_chance = 1;
            player_armor.crit_defence_amount = random.Next(4, 6);


            #endregion setting initial items

            #region Intro
            Console.WriteLine("\nWelcome, Adventurer {0}", player.player_name);
            Console.WriteLine("You are a {0}", player.player_class);
            Console.WriteLine(player.class_definition);
            Console.WriteLine("You come from the ancient city Aetheria. You have direct orders from the ruler to deliver a package across the land to Azurea's Domain");
            Console.WriteLine("\nYou only have 3 instructors.");
            Console.WriteLine("1) Do not open the package");
            Console.WriteLine("2) Do not let the package out of your sight");
            Console.WriteLine("3) Do what you must to ensure the package's delivery. You have permission to kill anyone and anything that gets in your way");
            Console.WriteLine("\nTo help you on your journey you are given 2 items. A rusted sword and Old Leather Armor");

            Console.WriteLine("Your sword's stats: ");
            Console.WriteLine("\tDamage: {0}", player_weapon.damage);
            Console.WriteLine("\tCrit Chance: {0}", player_weapon.crit_chance);
            Console.WriteLine("\tCrit Amount: {0}", player_weapon.crit_amount);

            Console.WriteLine("\nYour Armor's Stats: ");
            Console.WriteLine("\tDefence Amount: {0}", player_armor.defence_amount);
            Console.WriteLine("\tCritical Block Chance: {0}", player_armor.crit_defence_chance);
            Console.WriteLine("\tCritical Defence Amount: {0}", player_armor.crit_defence_amount);

            Console.WriteLine("\n\nThe start of your new adventure begins... Goodluck {0}", player.player_name);

            #endregion Intro


            #region shift_to_chapter_1
            /*
            Console.ForegroundColor = ConsoleColor.Green;

            var shifting_chatper_1 = new StreamReader("shift_to_chapter_1.txt");

            Console.ForegroundColor = ConsoleColor.Green;

            while (!shifting_chatper_1.EndOfStream)
            {
                Console.WriteLine(shifting_chatper_1.ReadLine());
                Thread.Sleep(2500);
            }
            shifting_chatper_1.Close();

            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(4934);
            */
            #endregion shift_to_chapter1

            #region Chapter 1

            Console.WriteLine("You step out of main gates and they slam shut behind you. You are now in a new land");
            Console.WriteLine("You see 3 paths in front of you, A thick and heavily forested area to your left, a mountain terrain to your right. And finally a flat plane straight ahead");
            Console.WriteLine("Just as you were about to make a decision you hear the gates creak open behind you, and out runs a messanger");
            Console.WriteLine("\"Before you leave, know that the paths ahead are not what they seem. What may be truth one day might be a lie the next\"");
            Console.WriteLine("It is now your choice", player.player_name, " where do you want to go");
            Console.WriteLine("A: The Forest\n\tYou can't see far into it. All you see are densly packed together trees, and you swear you hear a person sining an enchanting song");
            Console.WriteLine("B: The flat plane\n\tYou can see miles ahead and notice nothing of note");
            Console.WriteLine("C: The mountains\n\tThe path leading to the mountains are winding and will surely take longer then the other two paths, but you heard rumors of a treasure");

            string path_choice_1 = Console.ReadLine().ToLower();

            while (path_choice_1 != "a" && path_choice_1 != "b" && path_choice_1 != "c")
            {
                Console.WriteLine("That isn't a possible path. Your options are the following: ");
                Console.WriteLine("A: The densly packed forest");
                Console.WriteLine("B: The flat planes ahead of you");
                Console.WriteLine("C: The mountains to your right");

                path_choice_1 = Console.ReadLine().ToLower();
            }

            switch (path_choice_1)
            {
                case "a":
                    var skeleton_forest = new enemy("Skeleton", enemy_sword_types[0] , 10);
                    var slime_forest = new enemy("Slime", "Melee", 8);
                    var monkey = new enemy("Monkey", "Melee", 2);
                    var forest_boss = new enemy("Gate Guardian", enemy_sword_types[1], 15);

                    bool ran_away = false; //used to tell if player ran away form a fight

                    Console.WriteLine("\n\n\nYou start your adventure towards the densely packed forest to your left.");
                    Console.WriteLine("As you get closer and closer the sound of the mysterious voice gets louder and harder to ignore, along with your sense of dread");
                    Console.WriteLine("You start to make your way into the forest until you see something ontop of the trees");
                    Console.WriteLine("As you try and get a better look, the mysterious figure falls from the trees, a monkey");
                    Console.WriteLine("You try and walk around it, but it swpies at you, you have a feeling it won't go without a fight\n\n\n");

                    while (monkey.enemy_health > 0)
                    {
                        int enemy_choice, temp_damage, player_defence_chance, enemy_temp_defense;
                        Console.WriteLine("The Monkey's current health is: " + monkey.enemy_health);

                        enemy_choice = random.Next(1, 4);
                        
                        if (enemy_choice == 1)
                        {
                            Console.WriteLine("The looks at you with a confused, yet angry look on it's face");
                        }

                        if (enemy_choice == 2)
                        {
                            temp_damage = monkey.Attack();

                            player_defence_chance = random.Next(1, 26);



                            if (player.player_defense >= player_defence_chance)
                            {
                                temp_damage -= 2;

                                if (temp_damage < 0)
                                {
                                    temp_damage = 0;
                                }
                            }

                            Console.WriteLine("The " + monkey.enemy_name + " hits you for " + temp_damage);
                            player.player_health -= temp_damage;

                            if (player.player_health <= 0)
                            {
                                lose_forest();
                            }

                        }

                        if (enemy_choice == 3)
                        {
                            Console.WriteLine("The " + monkey.enemy_name + " appears to prepare itself for your next attack");

                            enemy_temp_defense = 1;
                        }


                        Console.WriteLine("\n\nIt is now your turn " +  player.player_name + ", You have 3 options");
                        Console.WriteLine("A: Attack the " + monkey.enemy_name +  " using your sword");
                        Console.WriteLine("B: Look closer at the "+ monkey.enemy_name + " in order to better understand your opponent");
                        Console.WriteLine("C: Run. This isn't your fight");
                        Console.WriteLine("You have " + player.player_health + " health remaining");

                        var player_choice = Console.ReadLine().ToLower();

                        while (player_choice != "a" && player_choice != "b" && player_choice != "c")
                        {
                            Console.WriteLine("You have entered an invalid option");
                            Console.WriteLine("You can either A: Attack, B: look closer at the enemy, C: Run");

                            player_choice = Console.ReadLine().ToLower();
                        }

                        switch (player_choice)
                        {
                            case "a":

                                Console.WriteLine("You attack " + monkey.enemy_name);
                                monkey.enemy_health -= player_weapon.damage;

                                break;

                            case "b":

                                Console.WriteLine("\n\nYou look closer at the " + monkey.enemy_name + " to see if you notice anythin");
                                Console.WriteLine("You notice the monkey doesn't have any weapons, armor, or forms of defence and attack other then it's paws");
                                Console.WriteLine("The expression of the monkey looks like it is confused but scared, not angry at you or wanting to stop you");
                                Console.WriteLine("You notice nothing else of note\n");
                                break;

                            case "c":

                                Console.WriteLine("You run away from the monkey, it doesn't run after you, let's hope this wasn't a mistake");
                                ran_away = true;

                                monkey.enemy_health = 0; //sets health to 0 to break out of the while loop
                                break;
                        }

                    }

                    if (!ran_away)
                    {
                        Console.WriteLine("Congrats! You have defeated the evil monkey, sure it seemed like a harmless animal but it got in your way and you had orders to kill anything that did that");
                        int exp_gained = random.Next(0, 25);
                        Console.WriteLine("You have gained ", exp_gained);
                        
                        player.exp += exp_gained;

                        if (player.exp >= player.next_level_exp_target)
                        {
                            player.exp = 0;
                            player.next_level_exp_target += 25;
                            player.level = 0;
                        }
                        else
                        {
                            Console.WriteLine("You have spared the monster.. Hopefully this wasn't a mistake");
                        }
                    }


                    Console.WriteLine("While you contiue thorugh the forest you see something shining, a mysterious green potion in a glass bottle laying on the ground next to a skeleton");
                    Console.WriteLine("You get the strange feeling that this potion could help you on your adventure if you drank it, as you open the bottle however a stench of death hits you");
                    Console.WriteLine("Do you drink the potion " + player.player_name + " y/n");
                    var drink_forest_potion_one = Console.ReadLine().ToLower();
                    
                    if (drink_forest_potion_one == "y")
                    {
                        Console.WriteLine("\n\nDespite the stench, you decide to drink the potion. It goes down your through and start to feel a tiny bit better then before");
                        Console.WriteLine("Your health has increased by one point");
                        player.player_health++;
                    }
                    else
                    {
                        Console.WriteLine("\n\nThe stench of death was to much to handle as you set down the drink not wanting to end up like the skeleton it was next to");
                    }

                    Console.WriteLine("A few steps after you set the bottle down, you hear the sound of bones rattling behind you.");
                    Console.WriteLine("You turn around and see the skeleton that was once on the ground now standing with a sword in it's hand. It starts to run at you");

                    while (skeleton_forest.enemy_health > 0)
                    {
                        int enemy_choice, temp_damage, player_defence_chance, enemy_temp_defense;
                        enemy_temp_defense = 0;

                        Console.WriteLine("The Skeleton's current health is: " + skeleton_forest.enemy_health);

                        enemy_choice = random.Next(1, 4);

                        if (enemy_choice == 1)
                        {
                            Console.WriteLine("The skeleton slashes it's sword in the air in an attempt to intimidate you");
                        }

                        if (enemy_choice == 2)
                        {
                            temp_damage = skeleton_forest.Attack();

                            player_defence_chance = random.Next(1, 26);



                            if (player.player_defense >= player_defence_chance)
                            {
                                temp_damage -= 2;

                                if (temp_damage < 0)
                                {
                                    temp_damage = 0;
                                }
                            }

                            Console.WriteLine("The " + skeleton_forest.enemy_name + " hits you for " + temp_damage);
                            player.player_health -= temp_damage;

                            if (player.player_health <= 0)
                            {
                                lose_forest();
                            }

                        }

                        if (enemy_choice == 3)
                        {
                            Console.WriteLine("The " + skeleton_forest.enemy_name + " appears to prepares itself for your next attack");

                            enemy_temp_defense = 2;
                        }


                        Console.WriteLine("\n\nIt is now your turn " + player.player_name + ", You have 3 options");
                        Console.WriteLine("A: Attack the " + skeleton_forest.enemy_name + " using your sword");
                        Console.WriteLine("B: Look closer at the " + skeleton_forest.enemy_name + " in order to better understand your opponent");
                        Console.WriteLine("C: Run. This isn't your fight");
                        Console.WriteLine("You have " + player.player_health + " health remaining");

                        var player_choice = Console.ReadLine().ToLower();

                        while (player_choice != "a" && player_choice != "b" && player_choice != "c")
                        {
                            Console.WriteLine("You have entered an invalid option");
                            Console.WriteLine("You can either A: Attack, B: look closer at the enemy, C: Run");

                            player_choice = Console.ReadLine().ToLower();
                        }


                        switch (player_choice)
                        {
                            case "a":

                                Console.WriteLine("You attack " + skeleton_forest.enemy_name);
                                skeleton_forest.enemy_health -= (player_weapon.damage - enemy_temp_defense);
                                Console.WriteLine("You hit the " + skeleton_forest.enemy_name + " for " + (player_weapon.damage - enemy_temp_defense));

                                break;

                            case "b":

                                Console.WriteLine("\n\nYou look closer at the " + skeleton_forest.enemy_name + " to see if you notice anythin");
                                Console.WriteLine("You notice the skeleton has a sword but no armor.");
                                Console.WriteLine("The skeleton is expressionless however it appears it doesn't have knowledge in sword fighting based on how it's holding its weapon");
                                Console.WriteLine("You notice nothing else of note\n");
                                break;

                            case "c":

                                Console.WriteLine("You attempt to run away from the skeleton");

                                var run_away_chance = random.Next(1, 30);

                                run_away_chance += player.player_stealth;

                                if (run_away_chance >= 30)
                                {
                                    Console.WriteLine("You have sucessfully ran way from the skeleton, let's hope it doesn't find you again");
                                    ran_away = true;
                                    skeleton_forest.enemy_health = 0; //0 to break out of the loop
                                }
                                else
                                {
                                    Console.WriteLine("You attempt to escape but the skeleton was able to catch you, you have taken 1 damage");
                                    player.player_health -= 1;

                                    if (player.player_health <= 0)
                                    {
                                        lose_forest();
                                    }
                                }
                                break;
                        }

                    }

                    if (!ran_away)
                    {
                        Console.WriteLine("Congrats! You have defeated the evil monkey, sure it seemed like a harmless animal but it got in your way and you had orders to kill anything that did that");
                        int exp_gained = random.Next(7, 35);
                        Console.WriteLine("You have gained ", exp_gained);

                        player.exp += exp_gained;

                        if (player.exp >= player.next_level_exp_target)
                        {
                            player.exp = 0;
                            player.next_level_exp_target += 25;
                            player.level = 0;
                            Console.WriteLine("Congratulations you have leveled up!");
                            Console.WriteLine("You have gained +1 defense +2 health");
                            player.player_defense += 1;
                            player.player_health += 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have spared the monster.. Hopefully this wasn't a mistake");
                    }
                    break;


                case "b":
                    Console.WriteLine("\n\n\nYou start on the path ahead of you, as you make your way across the flat ground in front of you, a questions of what you are missing pops in your mind");
                    Console.WriteLine("Though you have to deliver the package as soon as possible, you can't seem to shake the feeling that you are missing..... something");

                    break;

                case "c":
                    Console.WriteLine("\n\n\nThe idea of tresure fills your mind as you make your qay to the mountains");
                    Console.WriteLine("You start wondering if it'll be a sword, a hoarde of gold, or a one of a item item");

                    break;
            }

            #endregion Chpater 1

            //readfile test
            /*
            var file_test = new StreamReader("TestFile.txt"); //THIS IS PLACED IN "C:\Users\Onyx\Documents\c_sharp_testing\final_project\final_project\bin\Debug\TestFile.txt"

            Console.WriteLine(file_test.ReadLine());
            Console.WriteLine(file_test.ReadToEnd());
            */


            Console.ReadLine();
            
        }

        private static void lose_forest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            var forest_lost = new StreamReader("forest_lost.txt");

            while (!forest_lost.EndOfStream)
            {
                Console.WriteLine(forest_lost.ReadLine());
                Thread.Sleep(1000);
            }

            forest_lost.Close();
            Console.ForegroundColor = ConsoleColor.White;

            Environment.Exit(0); //gotten from chatGPT

        }
    }
}
