using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace App1.RestClient
{
    public class RestClient
    {
        private const string weburl = "http://10.0.1.107:55011/api/values/1057";

        public string GetResponse(int id)
        {
            string url = "http://10.0.1.107:55011/api/values/" + id;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Expect = "application/json";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            var rawJsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return rawJsonResponse;

        }

        public Employee JSONDesrilize(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Employee));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            Employee objStudent = (Employee)jsonSer.ReadObject(stream);
            return objStudent;
        }

    }
}
