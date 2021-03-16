using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeoStoreApp.Service.Login
{
    class LoginService
    {
        private ApiService _ApiService;
        private string SubBaseUrl = "users/login";
        public LoginService()
        {
            _ApiService = new ApiService();
        }

        //perform login task by calling apiservice where all methods (post,get,update) are stored.
        public ResponseModel<LoginResponseModel> PerformUserLogin(LoginRequestModel Request)
        {
            try
            {
                Dictionary<string, string> RequestDict = new Dictionary<string, string> {
                    { "email" , Request.email},
                    { "password", Request.password}
                };
               

                var Result = _ApiService.PerformPostRequest(SubBaseUrl, RequestDict);
                var Response = JsonConvert.DeserializeObject<ResponseModel<LoginResponseModel>>(Result);
                return Response;
            }
            catch (Exception Ex)
            {
                
                Console.WriteLine(Ex);
                return null;
            }
        }
    }
}
