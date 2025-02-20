using FluentValidation.Results;
using Ganss.Xss;
using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();
        private readonly Context _context;

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var value = messageManager.TGetListInbox(p);
            return View(value);
        }

        public ActionResult Outbox(string p)
        {
            var value = messageManager.TGetListOutbox(p);
            return View(value);
        }
        public ActionResult GetInboxDetails(int id)
        {
            var value = messageManager.TGetById(id);
            return View(value);
        }

        public ActionResult GetOutboxDetails(int id)
        {
            var value = messageManager.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            ValidationResult result = validator.Validate(message);
            if (result.IsValid)
            {
                message.Date = DateTime.Now;
                messageManager.TInsert(message);
                return RedirectToAction(nameof(Outbox));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = messageManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            messageManager.TUpdate(message);
            return RedirectToAction(nameof(Inbox));
        }
        public ActionResult DeleteMessage(int id)
        {
            messageManager.TDelete(messageManager.TGetById(id));
            return RedirectToAction(nameof(Inbox));
        }

        [HttpPost]
        [ValidateInput(false)] // HTML içeriğini temizlemek için
        public ActionResult SaveDraft(Message message)
        {
            message.Date = DateTime.Now;
            message.IsDraft = true;

            // HTML formatını temizleyerek kaydetmek istersen:
            var sanitizer = new HtmlSanitizer();
            message.MessageContent = sanitizer.Sanitize(message.MessageContent);

            messageManager.TInsert(message);
            return RedirectToAction("Inbox"); // Taslak kaydedildikten sonra Inbox'a dön
        }
        public ActionResult Drafts(Message message)
        {
            var value = messageManager.TGetListDrafts();
            return View(value);
        }

        [HttpGet]
        public ActionResult MarkAsRead(int id)
        {
            var message = messageManager.TGetById(id);

            if (message != null)
            {
                message.IsRead = !message.IsRead;  // Mevcut durumu tersine çevirir
                messageManager.TUpdate(message);  // Güncellenmiş mesajı kaydeder
            }
            return RedirectToAction("Inbox");
        }
    }
}