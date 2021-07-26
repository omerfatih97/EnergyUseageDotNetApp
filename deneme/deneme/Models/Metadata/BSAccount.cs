using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace deneme.Models
{
    public partial class DbModels : DbContext
    {

        public  string CheckUserAccount(string kullanici_adi, string sifre)
        {
            SqlParameter p1 = new SqlParameter("kullanici_adi", kullanici_adi);
            SqlParameter p2 = new SqlParameter("sifre", sifre);

            return this.Database.SqlQuery<string>("exec KullaniciBilgiAl @kullanici_adi,@sifre", p1, p2).FirstOrDefault();
        }
        
        public Kullanici getUserInfo(string username)
        {
            Kullanici veri = new Kullanici();

            var id = (from kullanici in Kullanicis
                      where kullanici.kullanici_adi == username
                      select new
                      {
                          kullanici.Id

                      });
            var img = (from resimler in resimlers
                       where resimler.user_id == id.FirstOrDefault().Id
                       select new
                       {
                           resimler.resim,
                       });

            if (img.FirstOrDefault() != null)
            {
                veri.resim = (byte[])img.FirstOrDefault().resim;
            }

            var user = (from kullanici in Kullanicis
                        where kullanici.Id == id.FirstOrDefault().Id
                        select new
                        {
                            kullanici.ad,
                            kullanici.sifre,
                            kullanici.soyad,
                            kullanici.tel,
                            kullanici.email,
                        });

            

            if (user.FirstOrDefault() != null)
            {
                veri.kullanici_adi = username;
                veri.ad = user.FirstOrDefault().ad;
                veri.soyad = user.FirstOrDefault().soyad;
                veri.sifre = user.FirstOrDefault().sifre;
                veri.tel = user.FirstOrDefault().tel;
                veri.email = user.FirstOrDefault().email;
            }

            return veri;
        }


        public Kullanici getUserById(String ui)
        {
            Kullanici veri = new Kullanici();

            var id = (from QR_Code in QR_Code
                      where QR_Code.code == ui
                      select new
                      {
                          QR_Code.user_id

                      });
            if (id.FirstOrDefault() != null)
            {
                var img = (from resimler in resimlers
                           where resimler.user_id == id.FirstOrDefault().user_id
                           select new
                           {
                               resimler.resim,
                           });
                if (img.FirstOrDefault() != null)
                {
                    veri.resim = (byte[])img.FirstOrDefault().resim;
                }


                var user = (from kullanici in Kullanicis
                            where kullanici.Id == id.FirstOrDefault().user_id
                            select new
                            {
                                kullanici.ad,
                                kullanici.kullanici_adi,
                                kullanici.sifre,
                                kullanici.soyad,
                                kullanici.tel,
                                kullanici.email,
                            });

                if (user.FirstOrDefault() != null)
                {
                    veri.kullanici_adi = user.FirstOrDefault().kullanici_adi;
                    veri.ad = user.FirstOrDefault().ad;
                    veri.soyad = user.FirstOrDefault().soyad;
                    veri.sifre = user.FirstOrDefault().sifre;
                    veri.tel = user.FirstOrDefault().tel;
                    veri.email = user.FirstOrDefault().email;
                }

                return veri;
            }
            return null;
                
        }

    }
}