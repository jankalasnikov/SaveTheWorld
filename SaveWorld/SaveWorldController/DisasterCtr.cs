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
    {/*
        User userData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
               
                var user = (from p in NWEntities.Ausers
                            where p.id == id
                            select p).FirstOrDefault();
                if (user != null)
                    userData = new User()
    {
        UserId = user.id,
                        Name = user.name,
                        Email = user.email,
                        Password = user.password,
                        Address = user.address,
                        Phone = user.phoneno,
                        TypeOfUser = user.typeOfUser,
                        BankAccountId = (int)user.accountId,

                    };
}
            return userData;*/
       
        /*public List<Disaster> ReadAll()
        {
            List<Disaster> dis = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var users = NWEntities.Disasters.ToList();
                if(users!=null)
                {
                    foreach (var disaster in users)
                    {
                        Disaster ob= new Disaster();
                        ob.Name = disaster.disasterName;
                        dis.Add(ob);
                    }
                }
               
            }
            return dis;
        }*/
    }
}
