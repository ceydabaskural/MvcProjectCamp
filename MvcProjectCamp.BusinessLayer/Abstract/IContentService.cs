using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> TGetList(string p);
        List<Content> TGetList();
        List<Content> TGetListByWriter(int id);
        List<Content> TGetListByHeadingId(int id);
        void TInsert(Content content);
        void TUpdate(Content content);
        void TDelete(Content content);
        Content TGetById(int id);
    }
}
