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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer TGetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.List();
        }

        public int TGetWritersWithA()
        {
            return _writerDal.GetWritersWithA();
        }

        public void TInsert(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void TUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
