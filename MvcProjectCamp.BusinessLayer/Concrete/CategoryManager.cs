using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TCountTrueOrFalse()
        {
            return _categoryDal.CountTrueOrFalse();
        }

        public void TDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public string TGetCategoryWithMostTitles()
        {
            return _categoryDal.GetCategoryWithMostTitles();
        }

        public List<Category> TGetList()
        {
            return _categoryDal.List();
        }

        public void TInsert(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void TUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
