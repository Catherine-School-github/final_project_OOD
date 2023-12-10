using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.npc_folder
{
    internal class enemy
    {
        Random random = new Random();


        public string enemy_name;
        public string enemy_weapon_type;
        public int enemy_health;

        //static bool melee_weapon;
        public enemy(string monster, string weapon, int health) 
        { 
            this.enemy_name = monster;
            this.enemy_weapon_type = weapon;
            this.enemy_health = health;
        }

        public int Attack()
        {
            int damage;

            switch (enemy_weapon_type)
            {
                case "Weak Sword":

                    damage = random.Next(1, 2);
                    break;

                case "Sword":

                    damage = random.Next(1, 4);
                    break;

                case "Strong Sword":

                    damage = random.Next(4, 6);
                    break;


                case "Bow":

                    damage = random.Next(2, 3);
                    break;

                case "Crossbow":

                    damage = random.Next(3, 5);
                    break;

                case "Slingshot":

                    damage = random.Next(1, 2);
                    break;

                default:

                    damage = 1;
                    break;

            }

            return damage;
        }

        
    }
}
