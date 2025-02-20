using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using MvcProjectCamp.Models;
using MvcProjectCamp.BusinessLayer.Abstract;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        AdminLoginManager adm = new AdminLoginManager(new EfAdminDal());

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            //Context c = new Context();
            //var value = c.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            var adminUserInfo = adm.GetAdmin(admin.AdminUsername, admin.AdminPassword);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUsername, false);
                Session["AdminUsername"] = adminUserInfo.AdminUsername;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> WriterLogin(Writer writer, string recaptchaResponse)
        {
            // Google reCAPTCHA doğrulama
            var secretKey = "6Lc9zdwqAAAAAHjrd11bzpGpkHRz-DqhoR20SzVk"; // Google'dan aldığınız Secret Key
            var response = recaptchaResponse;  // Formdan gelen reCAPTCHA yanıtı

            // reCAPTCHA API'sine istek gönderiyoruz
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
            {
                { "secret", secretKey },
                { "response", response }
            };

                var content = new FormUrlEncodedContent(values);
                var result = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

                var responseString = await result.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ReCaptchaResponse>(responseString);

                // reCAPTCHA doğrulaması başarılı ise devam et
                if (!obj.Success)
                {
                    // reCAPTCHA başarısızsa hata mesajı göster
                    ModelState.AddModelError("", "reCAPTCHA doğrulaması başarısız.");
                    return View(writer);  // Formu tekrar döndür
                }
            }

            // Kullanıcı bilgilerini doğrulama
            var writerUserInfo = wm.TGetWriter(writer.WriterMail, writer.WriterPassword);

            if (writerUserInfo != null)
            {
                // Doğrulama başarılıysa, giriş işlemleri
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                Session["WriterName"] = writerUserInfo.WriterName + " " + writerUserInfo.WriterSurname;
                Session["WriterImage"] = writerUserInfo.WriterImage;

                // Yazar paneline yönlendirme
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                // Kullanıcı bilgileri hatalıysa hata mesajı göster
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
                return View(writer);  // Formu tekrar döndür
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }
    }
}