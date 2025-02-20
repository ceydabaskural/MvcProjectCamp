using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void TDelete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public Heading TGetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);  //writer id 
        }

        public List<Heading> TGetHeadingList()
        {
            return _headingDal.List();
        }

        public List<Heading> TGetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public int TGetSoftwareHeadingsCount()
        {
            return _headingDal.GetSoftwareHeadingsCount();
        }

        public void TInsert(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void TUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
