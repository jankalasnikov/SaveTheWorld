using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
    public class DisasterCtr
    {
        public List<Disaster> GetAllDisasters()
        {
            
            List<Disaster> list = new List<Disaster>();
            using (SaveWorldEntities NWEntities = new SaveWorldEntities())
            {
                var allRows = NWEntities.Disasters.ToList();

                for (int i = 0; i < allRows.Count; i++)
                {
                    Disaster dis = new Disaster();
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
    }
}
