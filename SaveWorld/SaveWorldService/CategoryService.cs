using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveWorldController;
using SaveWorldModel;

namespace SaveWorldService
{
    public class CategoryService : ICategoryService
    {
        CategoryCtr categoryCtr = new CategoryCtr();

        public List<Category> GetAllCategories()
        {
            return categoryCtr.GetAllCategories();
        }

        public Category GetCategoryByName(string name)
        {
            return categoryCtr.GetCategoryByName(name);
        }

        public string GetCategoryNameById(int id)
        {
            return categoryCtr.GetCategoryNameById(id);
        }
    }
}
