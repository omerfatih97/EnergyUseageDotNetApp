using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace WebAPI.Controllers
{
  
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Kullanici Get(int id)
        {
            Kullanici veri = new Kullanici();
            using (DbModels dbModel = new DbModels())
            {
                var user = (from kullanici in dbModel.Kullanicis
                            where kullanici.Id == id
                            select new
                            {
                                kullanici.ad,
                                kullanici.kullanici_adi,
                                kullanici.soyad,
                                kullanici.tel,
                                kullanici.email,
                            }).FirstOrDefault();

                if (user != null)
                {
                    veri.kullanici_adi = user.kullanici_adi;
                    veri.ad = user.ad;
                    veri.soyad = user.soyad;
                    veri.tel = user.tel;
                    veri.email = user.email;
                }
            }
            
            //string json = JsonConvert.SerializeObject(new
            //{
            //    results = new List<Employee>()
            //    {
            //        new Employee { Id = 1, Name = "a", Addresss = "sdsad@gmail.com", PhoneNumber = "a" }
            //     }       
            //});

            return veri;

        }
        protected string SerializeMessageDCS<T>(T obj)

        {

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())

            using (System.IO.StreamReader reader = new System.IO.StreamReader(memoryStream))

            {

                System.Runtime.Serialization.DataContractSerializer serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));

                serializer.WriteObject(memoryStream, obj);

                memoryStream.Position = 0;

                return reader.ReadToEnd();

            }

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
