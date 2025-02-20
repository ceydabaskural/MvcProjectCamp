using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact TGetById(int id)
        {
            return _contactDal.Get(z => z.ContactId == id);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.List();
        }

        public void TInsert(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void TUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
