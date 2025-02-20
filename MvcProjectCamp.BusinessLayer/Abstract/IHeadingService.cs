using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> TGetHeadingList();
        Heading TGetById(int id);
        void TInsert(Heading heading);
        void TUpdate(Heading heading);
        void TDelete(Heading heading);
        List<Heading> TGetListByWriter(int id);
        int TGetSoftwareHeadingsCount();
    }
}
