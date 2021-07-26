using deneme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme.Controllers
{
    public class MainpageController : Controller
    {
        [HttpGet]
        public ActionResult KullaniciSayfasi()
        {
            Kullanici kmodel = new Kullanici();
            kmodel = (Kullanici)TempData["veri"];
            if (TempData["ui"] != null)
            {
                qr_sil();
            }
            return View(kmodel);
        }
        public ActionResult KullaniciUpdate(int id=0)
        {
            Kullanici kmodel = new Kullanici();
            kmodel = (Kullanici)TempData["veri"];
            return View(kmodel);
        }

        private void qr_sil()
        {
            DbModels db = new DbModels();
            try
            {
                using (var dbContext = new DbModels())
                {
                    string ui =(String) TempData["ui"];
                    var singleRec = dbContext.QR_Code.FirstOrDefault(x => x.code == ui );// object your want to delete
                    dbContext.QR_Code.Remove(singleRec);
                    dbContext.SaveChanges();
                }

                TempData["qr_text"] = null;
                TempData["ui"] = null;
                TempData["path"] = null;
            }
            catch(Exception e) { }
            /*var employer = new Employ { Id = 1 };
            ctx.Entry(employer).State = EntityState.Deleted;
            ctx.SaveChanges();*/
        }
    }
}


