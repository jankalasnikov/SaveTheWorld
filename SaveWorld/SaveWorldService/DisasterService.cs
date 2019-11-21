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
         DisasterCtrB disCtr = new DisasterCtrB();
            public List<DisasterB> GetAllDisasters()
            {
                return disCtr.GetAllDisasters();
            }

        public DisasterB GetDisasterByName(string name)
        {
            return disCtr.GetDisasterByName(name);
        }
        
    }
}
