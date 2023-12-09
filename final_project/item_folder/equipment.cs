using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.item_folder
{
    internal class equipment : item
    {
        public bool isLiquid;
        public equipment(string equipment_name, string equipment_description, bool solid_or_liquid)
        { 
            this.name = equipment_name;
            this.description = equipment_description;
            this.isLiquid = solid_or_liquid;
        }


    }
}
