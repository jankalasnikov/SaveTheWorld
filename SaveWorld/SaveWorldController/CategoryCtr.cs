using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
    public class CategoryCtr
    {
        CategoryDAL categoryDal = new CategoryDAL();
        public Category GetCategoryByName(string name)
        {
            return categoryDal.GetCategoryByName(name);
        }

        public string GetCategoryNameById(int id)
        {
            return categoryDal.GetCategoryNameById(id);
        }

        public List<Category> GetAllCategories()
        {
            return categoryDal.GetAllCategories();
        }
    }
}
