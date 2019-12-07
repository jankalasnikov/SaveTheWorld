﻿using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class DisasterDAL
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
                    dis.DisasterBankAccountId = (int)allRows[i].accountId;
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

        public bool CheckNameIfExists(string name)
        {
            bool exist = false;
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Disasters.Any(o => o.disasterName == name))
                {
                    exist = true;
                }
            }
            return exist;
        }

        public void DeleteDisaster(int id)
        {
            using (var NWEntities = new SaveWorldEntities())
            {
                var disaster = (from p in NWEntities.Disasters
                                where p.id == id
                                select p).FirstOrDefault();
                if (disaster != null)

                {

                    NWEntities.Disasters.Remove(disaster);
                    NWEntities.SaveChanges();
                };
            }
        }

        public bool UpdateDisaster(DisasterB disaster)
        {

            var updated = true;

            using (var NWEntities = new SaveWorldEntities())
            {
                var disasterId = disaster.DisasterId;
                var disasterDatabse =
                        (from p
                        in NWEntities.Disasters
                         where p.id == disasterId
                         select p).FirstOrDefault();

                if (disasterDatabse == null)
                {
                    throw new Exception("No disaster with ID " +
                                        disaster.DisasterId);
                }

                disasterDatabse.disasterName = disaster.Name;
                disasterDatabse.description = disaster.Description;
                disasterDatabse.priority = disaster.Priority;
                disasterDatabse.region = disaster.Region;
                disasterDatabse.victims = disaster.Victims;


                NWEntities.Disasters.Attach(disasterDatabse);


                NWEntities.Entry(disasterDatabse).State = System.Data.Entity.EntityState.Modified;


                var num = NWEntities.SaveChanges();


            }
            return updated;
        }

        public bool CreateDisaster(DisasterB newDisaster)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Disasters.Any(o => o.disasterName == newDisaster.Name))
                { return false; }



                disaster disaster = new disaster()
                {

                    disasterName = newDisaster.Name,
                    categoryId = newDisaster.CategoryId,
                    description = newDisaster.Description,
                    priority = newDisaster.Priority,
                    region = newDisaster.Region,
                    victims = newDisaster.Victims,
                    accountId = newDisaster.DisasterBankAccountId,
                };

                dbEntities.Disasters.Add(disaster);


                dbEntities.SaveChanges();

            }
            return true;
        }
    }
}
