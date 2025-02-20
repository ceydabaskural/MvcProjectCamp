using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> TGetList();
        void TInsert(Contact contact);
        Contact TGetById(int id);
        void TDelete(Contact contact);
        void TUpdate(Contact contact);
    }
}
