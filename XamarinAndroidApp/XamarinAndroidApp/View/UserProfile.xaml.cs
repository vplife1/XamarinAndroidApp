using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
       

        public UserProfile()
        {
            InitializeComponent();
            LoadData();
        }
     
        public async void LoadData()
        {

            string myData = "{\"filter\": {\"labtestName\": [{\"labtestName\": \"Ada\"}]}}";
            //string data1 = "{\filter\":  {\"labtestName\": [{\"labtestName\": \"Ada\"}]}}";
            var RestURL = "https://tcdevapi.iworktech.net/v1api/LabTest/HSCLabTests";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestURL);

                StringContent content1 = new StringContent(myData, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("apptoken", "72f303a7-f1f0-45a0-ad2b-e6db29328b1a");
                client.DefaultRequestHeaders.Add("usertoken", "cZJqFMitFdVz5MOvRLT7baVTJa+yZffc5eVoU91OqkMYl6//cQmgIVkHOyRZ7rWTXi66WV4tMEuj+0oHIyPS6hBvPUY5/RJ7oWnTr4LuzlKU1H7Cp68za57O9AatAJJHiVPowlXwoPUohqe8Ad2u0A==");
                HttpResponseMessage response = await client.PostAsync(RestURL, content1);
                var result = await response.Content.ReadAsStringAsync();
                UserData responseData = JsonConvert.DeserializeObject<UserData>(result);
               
                var data = responseData.Results.LabTestData;
             
                var ll = new List<string>();
                if (responseData != null && responseData.Results != null && responseData.Results.LabTestData != null)
                {
                    LabTestData.ItemsSource = responseData.Results.LabTestData;
                    
                    await Task.Delay(2000);
                    IsRefreshing = false;
                }


            }

               
            


        }

        public Command RefreshData
        {
            get
            {
                return new Command(() => {

                    LoadData();
                    

                });
            }
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


       
    }

    public class LabtestName
    {
        public string labtestName { get; set; }
    }



    public class Filter
    {
        public List<LabtestName> labtestName { get; set; }
    }



    public class Root
    {
        public Filter filter { get; set; }
    }



   




}