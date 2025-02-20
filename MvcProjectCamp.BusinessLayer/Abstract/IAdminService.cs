using MvcProjectCamp.EntityLayer;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> TGetList();
        void TInsert(Admin admin);
        void TUpdate(Admin admin);
        void TDelete(Admin admin);
        Admin TGetById(int id);
    }
}
