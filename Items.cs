using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    public class Item
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }

        public Item(string name, string effect, string description)
        {
            Name = name;
            Effect = effect;
            Description = description;

            //Assign effect method
        }


    }
}
