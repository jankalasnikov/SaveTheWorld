using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Disaster
    {
        private String Name { get; set; }
        private String Description { get; set; } 
        private String Region { get; set; }
        private String Category { get; set; }
        private double Priority { get; set; }
        private int Victims { get; set; }

        public Disaster()
        {

        }

        public Disaster(String name, String description, String region, String category, double priority, int victims)
        {
            Name = name;
            Description = description;
            Region = region;
            Category = category;
            Priority = priority;
            Victims = victims;
        }
    }
}
