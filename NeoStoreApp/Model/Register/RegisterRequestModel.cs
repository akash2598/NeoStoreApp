using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Model.Register
{
    class RegisterRequestModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public string gender { get; set; }
        public string phone_no { get; set; }

       
    }
}
