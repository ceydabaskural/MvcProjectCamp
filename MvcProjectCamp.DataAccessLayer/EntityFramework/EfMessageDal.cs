using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.Repositories;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        Context c = new Context();
        public List<Message> GetListDrafts()
        {
            var value = c.Messages.Where(x => x.IsDraft == true).ToList();
            return value;
        }
    }
}
