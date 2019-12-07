using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class DisasterCtrB
    {
        DisasterDAL disasterDal = new DisasterDAL();
        public List<DisasterB> GetAllDisasters()
        {
            return disasterDal.GetAllDisasters();
        }


        public DisasterB GetDisasterByName(string name)
        {
            return disasterDal.GetDisasterByName(name);
        }

        public bool CheckNameIfExists(string name)
        {
            return disasterDal.CheckNameIfExists(name);
        }

        public void DeleteDisaster(int id)
        {
            disasterDal.DeleteDisaster(id);
        }

        public bool UpdateDisaster(DisasterB disaster)
        {
            return disasterDal.UpdateDisaster(disaster);
        }

        public bool CreateDisaster(DisasterB newDisaster)
        {
            return disasterDal.CreateDisaster(newDisaster);
        }

    }
}
