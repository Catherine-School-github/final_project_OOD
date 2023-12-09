using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.item_folder
{
    internal class armor : item
    {
        public armor(string armor_name, string armor_description)
        {
            this.name = armor_name;
            this.description = armor_description;
        }

        public bool isHeavy {  get; set; }
        public int defence_amount {  get; set; }
        public float crit_defence_chance { get; set; }
        public int crit_defence_amount { get; set; }
    }
}
