using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.Repositories;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        Context _context = new Context();
        public int CountTrueOrFalse()
        {
            var valueTrue = _context.Categories.Count(x => x.Status == true);
            var valueFalse = _context.Categories.Count(x => x.Status == false);
            return valueTrue - valueFalse;
        }

        public string GetCategoryWithMostTitles()
        {
            return _context.Headings.GroupBy(x => x.Category.CategoryName).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
        }
    }
}
