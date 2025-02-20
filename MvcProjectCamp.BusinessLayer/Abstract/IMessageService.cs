using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> TGetListInbox(string p);
        List<Message> TGetListOutbox(string p);
        void TInsert(Message message);
        void TUpdate(Message message);
        void TDelete(Message message);
        Message TGetById(int id);
        List<Message> TGetListDrafts();
    }
}
