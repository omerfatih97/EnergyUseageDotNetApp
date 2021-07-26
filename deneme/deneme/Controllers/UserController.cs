using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneme.Models;

namespace deneme.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [HttpGet]
        public ActionResult Kayit(int id=0)
        {
            Kullanici kmodel = new Kullanici();
            return View(kmodel);
        }

        [HttpPost]
        public ActionResult Kayit(Kullanici kmodel, HttpPostedFileBase file)
        {
            using(DbModels dbModel =new DbModels())
            {
                try
                {
                    if (kmodel.agree && !string.IsNullOrEmpty(kmodel.ad) && !string.IsNullOrEmpty(kmodel.soyad) && !string.IsNullOrEmpty(kmodel.kullanici_adi) && !string.IsNullOrEmpty(kmodel.sifre) && kmodel.sifre.Equals(kmodel.sifredogrula))
                    {
                        kmodel.sifre = Crypto.Hash(kmodel.sifre);
                        kmodel.sifredogrula = Crypto.Hash(kmodel.sifredogrula);
                        
                        dbModel.Kullanicis.Add(kmodel);
                        dbModel.SaveChanges();
                        if (file != null)
                        {
                            var temp = ConvertToBytes(file);
                            dbModel.resimlers.Add(new resimler() { resim = temp, user_id = kmodel.Id });
                            dbModel.SaveChanges();
                        }
                        
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(kmodel.ad) || string.IsNullOrEmpty(kmodel.soyad) || string.IsNullOrEmpty(kmodel.kullanici_adi) || string.IsNullOrEmpty(kmodel.sifre))
                            TempData["kayit"] = "Lütfen (*) ile İşaretli Boş Bıraktığınız Alanları Doldurunuz.";
                        else if (!kmodel.agree)
                            TempData["kayit"] = "Koşulları Kabul Etmeniz Gerekmektedir.";
                        else
                            TempData["kayit"] = "Hata";
                        return RedirectToAction("Kayit", "User");
                    }
                }
                catch(Exception e)
                {
                    ModelState.Clear();
                    TempData["Referrer"] = e.ToString();
                    return RedirectToAction("Kayit", "User");
                }
            }
            ModelState.Clear();
            TempData["Referrer"] = "SuccessMessage";
            return RedirectToAction("Index", "Home");
        }
        
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public byte[] imageToByteArray(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }


    }
}