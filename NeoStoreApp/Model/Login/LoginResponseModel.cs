using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Model.Login
{
   public class LoginResponseModel
    {
        public int id { get; set; }
        public int role_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string profile_pic { get; set; }
        public string country_id { get; set; }
        public string gender { get; set; }
        public int phone_no { get; set; }
        public string dob { get; set; }
        public bool is_active { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string access_token { get; set; }
    }
}
