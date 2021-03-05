using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAndroidApp.Model
{
   public class Results
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "RememberMe")]
        public bool RememberMe { get; set; }
        [JsonProperty(PropertyName = "Centers")]
        public string Centers { get; set; }
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "RoleName")]
        public string RoleName { get; set; }
        [JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "PhleboCenter")]
        public string PhleboCenter { get; set; }
        [JsonProperty(PropertyName = "PhleboContactNumber")]
        public string PhleboContactNumber { get; set; }

   }




}
