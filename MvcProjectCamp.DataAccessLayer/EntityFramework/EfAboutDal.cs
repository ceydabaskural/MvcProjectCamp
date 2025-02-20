using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Repositories;
using MvcProjectCamp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About> , IAboutDal
    {
    }
}
