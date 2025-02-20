using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> TGetList();
        void TInsert(Writer writer);
        void TUpdate(Writer writer);
        void TDelete(Writer writer);
        Writer TGetById(int id);
        int TGetWritersWithA();
    }
}
