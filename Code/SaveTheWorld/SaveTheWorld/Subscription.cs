using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Subscription
    {
        private int periodOfTime { get; set; }
        private String typeOfSubscription { get; set; }
        private int amount { get; set; }
        private String startDate { get; set; }

        public Subscription()
        {

        }

        public Subscription(int periodOfTime, String typeOfSubscription, int amount, String startDate)
        {
            this.periodOfTime = periodOfTime;
            this.typeOfSubscription = typeOfSubscription;
            this.amount = amount;
            this.startDate = startDate;
        }
    }
}
