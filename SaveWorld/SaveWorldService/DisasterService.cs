using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
   public class DisasterService : IDisasterService
    {
        DisasterCtr disCtr = new DisasterCtr();
        public List<Disaster> GetAllDisasters()
        {
            return disCtr.GetAllDisasters();
        }
    }
}
