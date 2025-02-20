using FluentValidation.Results;
using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator validations = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var value = mm.TGetListInbox(p);
            return View(value);
        }
        public ActionResult Outbox(int id)
        {
            string p = (string)Session["WriterMail"];
            var value = mm.TGetListOutbox(p);
            return View(value);
        }
        public PartialViewResult MessageSideBar()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }
        public ActionResult GetOutboxMessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        [HttpGet]//ders 76
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = validations.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = sender;
                message.Date = DateTime.Now;
                mm.TInsert(message);
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
    }
}