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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void TDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content TGetById(int id)
        {
            return _contentDal.Get(z => z.ContentId == id);
        }

        public List<Content> TGetList(string p)
        {
            return _contentDal.List(z => z.ContentValue.Contains(p));
        }

        public List<Content> TGetList()
        {
            return _contentDal.List();
        }

        public List<Content> TGetListByHeadingId(int id)
        {
            return _contentDal.List(z => z.HeadingId == id);
        }

        public List<Content> TGetListByWriter(int id)
        {
            return _contentDal.List(z => z.WriterId == id);
        }

        public void TInsert(Content content)
        {
            _contentDal.Insert(content);
        }

        public void TUpdate(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
