using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Subscription
    {
        private int PeriodOfTime { get; set; }
        private String TypeOfSubscription { get; set; }
        private int Amount { get; set; }
        private DateTime StartDate { get; set; }

        public Subscription()
        {

        }

        public Subscription(int periodOfTime, String typeOfSubscription, int amount, DateTime startDate)
        {
            PeriodOfTime = periodOfTime;
            TypeOfSubscription = typeOfSubscription;
            Amount = amount;
            StartDate = startDate;
        }
    }
}
