using MvcProjectCamp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> TGetList();
        void TInsert(About about);
        void TUpdate(About about);
        void TDelete(About about);
        About TGetById(int id);
    }
}
