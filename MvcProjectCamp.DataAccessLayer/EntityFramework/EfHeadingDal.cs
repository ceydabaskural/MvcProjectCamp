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
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        Context _context = new Context();

        public int GetSoftwareHeadingsCount()
        {
            return _context.Set<Heading>()
                .Count(h => h.Category.CategoryName == "Software");
        }
    }
}
