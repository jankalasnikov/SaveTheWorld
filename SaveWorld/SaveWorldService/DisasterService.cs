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

        public bool CheckNameIfExists(string name)
        {
            return disCtr.CheckNameIfExists(name);
        }

        public bool UpdateDisaster(DisasterB disaster)
        {
            return disCtr.UpdateDisaster(disaster);
        }

        public void DeleteDisaster(int id)
        {
            disCtr.DeleteDisaster(id);
        }

    }
}
