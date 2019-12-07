using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class CategoryDAL
    {
        public Category GetCategoryByName(string name)
        {
            Category category = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                var cat = (from p in NWEntities.Category
                           where p.nameOfCategory == name
                           select p).FirstOrDefault();
                if (cat != null)
                    category = new Category()
                    {
                        CatogoryId = cat.id,
                        NameOfCategory = cat.nameOfCategory,


                    };
            }
            return category;

        }

        public string GetCategoryNameById(int id)
        {
            Category category = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                var cat = (from p in NWEntities.Category
                           where p.id == id
                           select p).FirstOrDefault();
                if (cat != null)
                    category = new Category()
                    {
                        CatogoryId = cat.id,
                        NameOfCategory = cat.nameOfCategory,


                    };
            }
            return category.NameOfCategory;

        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            using (SaveWorldEntities NWEntities = new SaveWorldEntities())
            {
                var ptx = (from r in NWEntities.Category select r);
                var allRows = NWEntities.Category.ToList();

                for (int i = 0; i < allRows.Count; i++)
                {
                    Category cat = new Category();
                    cat.CatogoryId = allRows[i].id;
                    cat.NameOfCategory = allRows[i].nameOfCategory;

                    list.Add(cat);

                }
            }
            return list;
        }
    }
}
