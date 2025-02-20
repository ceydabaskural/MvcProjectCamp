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
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        Context _context = new Context();
        public int GetWritersWithA()
        {
            return _context.Writers.Count(a => a.WriterName.Contains("a") || a.WriterName.Contains("A"));
        }
    }
}
