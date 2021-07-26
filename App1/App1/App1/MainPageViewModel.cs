using App1.RestClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
                
        public MainPageViewModel()
        {
            GetEmployees();
        }

        public async void GetEmployees()
        {

            var client = new RestClient.RestClient();
            var rawJsonResponse = client.GetResponse(1057);
            List<Employee> ObjContactList = new List<Employee>();
            if (rawJsonResponse != "")
            {
                var s = removeblanks(rawJsonResponse);
                Employee myObject = client.JSONDesrilize(s);
                ObjContactList.Add(myObject);
            }
            Employees = new ObservableCollection<Employee>(ObjContactList);
        }

        private string removeblanks(string str)
        {
            return str.Replace(" ", "");
        }


        bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
