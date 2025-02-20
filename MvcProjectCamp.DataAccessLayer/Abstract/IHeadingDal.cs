using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.DataAccessLayer.Abstract
{
    public interface IHeadingDal : IRepositoryDal<Heading>
    {
        int GetSoftwareHeadingsCount();
    }
}
