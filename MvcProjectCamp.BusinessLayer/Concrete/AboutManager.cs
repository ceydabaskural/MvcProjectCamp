using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public About TGetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.List();
        }

        public void TInsert(About about)
        {
            _aboutDal.Insert(about);
        }

        public void TUpdate(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
