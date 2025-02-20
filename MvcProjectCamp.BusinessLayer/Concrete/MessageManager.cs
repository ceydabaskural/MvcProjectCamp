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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message TGetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id); 
        }

        public List<Message> TGetListDrafts()
        {
            return _messageDal.GetListDrafts();
        }

        public List<Message> TGetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> TGetListOutbox(string p)
        {
            return _messageDal.List(z => z.SenderMail == p);
        }

        public void TInsert(Message message)
        {
            _messageDal.Insert(message);
        }


        public void TUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
