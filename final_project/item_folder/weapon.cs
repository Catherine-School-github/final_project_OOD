using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.item_folder
{
    internal class weapon : item
    {

        public weapon(string weapon_name, string weapon_description)
        {
            this.name = weapon_name;
            this.description = weapon_description;
        }
        
        public int damage { get; set; }
        public bool isRange {  get; set; }
        public float crit_chance { get; set; }
        public float crit_amount { get; set; }

    }
}
