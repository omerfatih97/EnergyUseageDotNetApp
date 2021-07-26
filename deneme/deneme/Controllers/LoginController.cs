using deneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            TempData["sonuc"] = "bos";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanici model)
        {
            DbModels cbe = new DbModels();
            if(!string.IsNullOrEmpty(model.kullanici_adi) && !string.IsNullOrEmpty(model.sifre))
            {
               
                var item = cbe.CheckUserAccount(model.kullanici_adi, Crypto.Hash(model.sifre));

                if (item.ToString().Equals("Basarili"))
                {
                    TempData["sonuc"] = item.ToString();
                    TempData["kullanici"] = model.kullanici_adi;

                    Kullanici veri = cbe.getUserInfo(model.kullanici_adi);

                    if (veri != null)
                    {
                        TempData["veri"] = veri;
                        return RedirectToAction("KullaniciSayfasi", "Mainpage");
                    }
                    else
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["sonuc"] = item.ToString();
                    return View("Login");
                }

            }
            else
            {
                TempData["sonuc"] = " * Lütfen Boş Bıraktığınız Alanı Doldurunuz.";
                return View("Login");
            }
            
        }


        public int db_control(String ui)
        {
            DbModels cbe = new DbModels();

            Kullanici veri = cbe.getUserById(ui);

            try
            {
                if (veri.kullanici_adi != null)
                {
                    TempData["sonuc"] = "Basarili";
                    TempData["kullanici"] = veri.kullanici_adi;
                    TempData["veri"] = veri;
                    TempData.Keep();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public JsonResult GetData()
        {
            TempData.Keep("qr_text");
            if (TempData.ContainsKey("qr_text"))
            {
                try
                {
                    if (db_control(TempData["qr_text"].ToString()) == 0) { TempData["veri"] = null; TempData.Keep(); }
                    else { return Json(true, JsonRequestBehavior.AllowGet); }
                }
                catch (Exception e) { TempData["veri"] = null; return Json(false, JsonRequestBehavior.AllowGet); }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DelQr()
        {
            DbModels db = new DbModels();
            
            TempData.Keep("qr_text");
            if (TempData.ContainsKey("qr_text"))
            {
                try
                {
                    String qr = TempData["qr_text"].ToString();
                    var valDelete = db.QR_Code.Single(a => a.code == qr);
                    db.QR_Code.Remove(valDelete);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e) { TempData["veri"] = null; return Json(false, JsonRequestBehavior.AllowGet); }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public String ui()
        {
            initial();
            var guid = Guid.NewGuid();
            ui_ekle(guid.ToString());
            TempData["gui"] = guid.ToString();
            TempData.Keep("gui");
            return guid.ToString();
        }

        public void ui_ekle(String ui)
        {

            using (DbModels dbModel = new DbModels())
            {
                dbModel.QR_Code.Add(new QR_Code() { code = ui });
                dbModel.SaveChanges();
            }

        }

        private void initial()
        {
            TempData["gui"] = null;
            TempData["qr_text"] = null;
            TempData["sonuc"] = null;
            TempData["kullanici"] = null;
            TempData["veri"] = null;
            TempData.Keep();
        }
    }
}