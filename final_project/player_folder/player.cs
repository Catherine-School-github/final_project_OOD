using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    internal class player
    {
        #region vars
        public string player_name;
        public string color;

        public int exp;
        public int level;
        public int next_level_exp_target;
        #endregion vars

        public player(string name)
        {
            player_name = name;
            exp = 0;
            level = 1;
            next_level_exp_target = 50;
        }


        #region player information
        public string player_class { get; set; }
        public int player_health { get; set; }
        public int player_defense { get; set; }
        public int player_strength { get; set; }
        public int player_speed { get; set; }
        public int player_stealth { get; set; }
        public int player_charisma {  get; set; }
        public string class_definition {  get; set; }

        #endregion player information






    }
}
