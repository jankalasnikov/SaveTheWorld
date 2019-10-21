using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Disaster
    {
        private String name { get; set; }
        private String description { get; set; } 
        private String region { get; set; }
        private String category { get; set; }
        private double priority { get; set; }
        private int victims { get; set; }

        public Disaster()
        {

        }

        public Disaster(String name, String description, String region, String category, double priority, int victims)
        {
            this.name = name;
            this.description = description;
            this.region = region;
            this.category = category;
            this.priority = priority;
            this.victims = victims;
        }
    }
}
