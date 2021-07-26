using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabPage2 : ContentPage
	{
        private ObservableCollection<Employee> myList;

        public ObservableCollection<Employee> MyList
        {
            get { return myList; }
            set { myList = value; }
        }

        public TabPage2 ()
		{
			InitializeComponent ();

            this.BindingContext = this;
            GetJSON();
            ContactsList.ItemsSource = MyList;

        }

        public async void GetJSON()
        {
            MyList = new ObservableCollection<Employee>();
            //Check network status   
            if (NetworkCheck.IsInternet())
            {

                try
                {
                    var client = new RestClient.RestClient();
                    var rawJsonResponse = client.GetResponse(1057);
                    List<Employee> ObjContactList = new List<Employee>();
                    if (rawJsonResponse != "")
                    {
                        var s = removeblanks(rawJsonResponse);
                        Employee myObject = client.JSONDesrilize(s);
                        MyList.Add(myObject);
                        MessagingCenter.Send(this, "MyCommandName", myObject.ad);
                    }

                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, "MyCommandName", "");
                    await DisplayAlert("Hata!!!", "API veri çekme işlemi sırasında hata oluştu!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Hata!!!", "İnternet Bağlantısı Yoktur. Lütfen İnternet Bağlantınızı Açınız!", "Ok");
            }
        }

        private string removeblanks(string str)
        {
            return str.Replace(" ", "");
        }

        /*private void btnSendSozlesme_Click(object sender, EventArgs e)
        {
            try
            {


                Employee RequestData = new Employee()
                {
                    basvuruNo = txtBsvuruNo.Text,
                    kimlikNo = txtKimlikNo.Text,
                    imzaliPdfBase64 = "imza_" + Sozlesme
                };

                MemoryStream memStream = new MemoryStream();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(SendSozlesmeRequest));

                jsonSerializer.WriteObject(memStream, RequestData);

                string json = Encoding.UTF8.GetString(memStream.ToArray(), 0, (int)memStream.Length);

                //string json = "{" + string.Format("\"kimlikNo\":\"{0}\",\"basvuruNo\":\"{1}\"",txtKimlikNo.Text,txtBsvuruNo)+"}";

                string url = "http://localhost/Codebase.Energy.Perakende.WcfServices/Ext/EDevletEImzaService.svc/SendImzaliSozlesme";


                byte[] data = Encoding.UTF8.GetBytes(json); // a json object, or xml, whatever...

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";

                request.GetRequestStream().Write(data, 0, data.Length);

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;



                var rawJsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();

                // Deserialization from JSON  

                SendSozlesmeResponse sendResponse = null;
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(rawJsonResponse)))
                {
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(SendSozlesmeResponse));
                    sendResponse = (SendSozlesmeResponse)deserializer.ReadObject(ms);
                }

                txtOutput.Text = sendResponse.sonucAciklamasi;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

    }
}