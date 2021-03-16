using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.Register;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeoStoreApp.Service.Register
{
    class RegisterService
    {
        private ApiService _ApiService;
        private string SubBaseUrl = "users/register";
        public RegisterService()
        {
            _ApiService = new ApiService();
        }
        //perform register task by calling apiservice where all methods (post,get,update) are stored.
        public ResponseModel<RegisterResponeModel> PerformUserRegister(RegisterRequestModel Request)
        {
            try
            {
                //calling base post method which is in apiservice for post method
                
                Dictionary<string, string> RequestDict = new Dictionary<string, string> {
                    { "first_name" , Request.firstName},
                    { "last_name", Request.lastName},
                    { "email", Request.email},
                     { "password", Request.password},
                      { "confirm_password", Request.confirm_password},
                       { "gender", Request.gender},
                        { "phone_no", Request.phone_no}



                };
                var Result = _ApiService.PerformPostRequest(SubBaseUrl, RequestDict);
                var Response = JsonConvert.DeserializeObject<ResponseModel<RegisterResponeModel>>(Result);
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                 Application.Current.MainPage.DisplayAlert("RegisterService", Ex.Message, "OK");
                return null;
            }
        }
    }
}
