using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private ObservableCollection<Results> _post;
        public LoginPage()
        {
            InitializeComponent();
            LoadData();

        }
       



        public async void LoadData()
        {
           


            var data = new
            {
                phleboMobileNumber = "9130361749",
                mpinCode = "1111"
            };
            var content = "";

            


            var RestURL = "https://tcdevapi.iworktech.net/v1api/Phlebotomists/phlebotomistLogin";
            HttpClient client = new HttpClient();
            string jsonData = JsonConvert.SerializeObject(data);
            client.BaseAddress = new Uri(RestURL);

            StringContent content1 = new StringContent(jsonData, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("apptoken", "72f303a7-f1f0-45a0-ad2b-e6db29328b1a");
            client.DefaultRequestHeaders.Add("usertoken", "51QA3gF4ZjnDsUL4q8g84t1QcTTlhCGiEdqBcbrIDULqSKHDjOVBY98XsOqXWbWKKQjHoedkt38tsUj9MylnsA5GXtcQQOopimk5IcihfGGessmP6lMs6unVvE30kPWWxMKf0M0zJZEPzUgKGokz9Q==");
            HttpResponseMessage response = await client.PostAsync(RestURL, content1);            
           var  result = await response.Content.ReadAsStringAsync();
               var responseData = JsonConvert.DeserializeObject<Response>(result);
        

            var ll = new List<string>();
             String Id=Convert.ToString(responseData.Results.Id);
            if(responseData!=null && responseData.Results != null)
            {

                ll.Add(Id);
                ll.Add(responseData.Results.FullName);
                ll.Add(responseData.Results.FirstName);
                ll.Add(responseData.Results.LastName);
                ll.Add(responseData.Results.RoleName);
                ll.Add(responseData.Results.PhleboContactNumber);
                ll.Add(responseData.Results.Centers);
                ll.Add(responseData.Results.PhleboCenter);
              
               

            }
     

        ListView1.ItemsSource = ll;

             
        }




        public Command RefreshData
        {
            get
            {
                return new Command(()=>{

                    LoadData(); 

                });
            }
        }


   
       



        string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (value != null)
                {
                    _Email = value;
                    OnPropertyChanged();
                }
            }
        }
        string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (value != null)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (value != null)
                {
                    _FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

            bool _Refreshing;
        public bool Refreshing
        {
            get
            {
                return _Refreshing;
            }
            set
            {
                if (value != null)
                {
                    _Refreshing = value;
                    OnPropertyChanged();
                }
            }
        }


        int _ID;
        public int Id
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value != null)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }


        bool _RememberMe;
        public bool RememberMe
        {
            get
            {
                return _RememberMe;
            }
            set
            {
                if (value != null)
                {
                    _RememberMe = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Centers;
        public string Centers
        {
            get
            {
                return _Centers;
            }
            set
            {
                if (value != null)
                {
                    _Centers = value;
                    OnPropertyChanged();
                }
            }
        }
        string _RoleName;
        public string RoleName
        {
            get
            {
                return _RoleName;
            }
            set
            {
                if (value != null)
                {
                    _RoleName = value;
                    OnPropertyChanged();
                }
            }
        }

        string _FullName;
        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                if (value != null)
                {
                    _FullName = value;
                    OnPropertyChanged();
                }
            }
        }

        string _PhleboCenter;
        public string PhleboCenter
        {
            get
            {
                return _PhleboCenter;
            }
            set
            {
                if (value != null)
                {
                    _PhleboCenter = value;
                    OnPropertyChanged();
                }
            }

        }
        string _PhleboContactNumber;
        public string PhleboContactNumber
        {
            get
            {
                return _PhleboContactNumber;
            }
            set
            {
                if (value != null)
                {
                    _PhleboContactNumber = value;
                    OnPropertyChanged();
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }


}