using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> TGetList();
        void TInsert(Category category);
        Category TGetById(int id);
        void TDelete(Category category);
        void TUpdate(Category category);
        string TGetCategoryWithMostTitles();
        int TCountTrueOrFalse();
    }
}
