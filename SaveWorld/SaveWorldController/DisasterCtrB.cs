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
        public List<DisasterB> GetAllDisasters()
        {

            List<DisasterB> list = new List<DisasterB>();
            using (SaveWorldEntities NWEntities = new SaveWorldEntities())
            {
                var allRows = NWEntities.Disasters.ToList();

                for (int i = 0; i < allRows.Count; i++)
                {
                    DisasterB dis = new DisasterB();
                    dis.Name = allRows[i].disasterName;
                    dis.DisasterId = allRows[i].id;
                    dis.Description = allRows[i].description;
                    dis.CategoryId = (int)allRows[i].categoryId;
                    dis.Region = allRows[i].region;
                    dis.Victims = allRows[i].victims;
                    dis.Priority = allRows[i].priority;
                    list.Add(dis);

                }
            }
            return list;
        }


        public DisasterB GetDisasterByName(string name)
        {
            DisasterB disData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var dis = (from p in NWEntities.Disasters
                               where p.disasterName == name
                               select p).FirstOrDefault();
                if (dis != null)
                    disData = new DisasterB()
                    {
                        DisasterId = dis.id,
                        Name = dis.disasterName,
                        Description = dis.description,
                        Priority = dis.priority,
                        Region = dis.region,
                        Victims = dis.victims,
                        CategoryId = (int)dis.categoryId,
                        DisasterBankAccountId = (int)dis.accountId,
                    };
            }
            return disData;
        }
    }
}
