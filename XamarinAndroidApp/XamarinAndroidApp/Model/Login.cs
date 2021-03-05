using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAndroidApp.Model
{
    public class Login
    {
        [JsonProperty("results")]
        public List<Results> results { get; set; }
       
        Response response { get; set; }
    }
}
