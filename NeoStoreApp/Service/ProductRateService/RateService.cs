using System;
using System.Collections.Generic;
using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.RateModel;
using Newtonsoft.Json;

namespace NeoStoreApp.Service.ProductRateService
{
    public class RateService
        
    {
        ApiService _ApiService = new ApiService();
        private string SubBaseUrl = "products/setRating";

        public RateService()
        {
        }

        public ResponseModel<RateResponseModel> SetRating(RateRequestModel Request)
        {
            try
            {
                Dictionary<string, string> RequestDict = new Dictionary<string, string> {
                    { "product_id" ,Convert.ToString(Request.product_id)},
                    { "rating", Request.rating}
                };
               
                var Result = _ApiService.PerformPostRequest(SubBaseUrl, RequestDict);
                var Response = JsonConvert.DeserializeObject<ResponseModel<RateResponseModel>>(Result);
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
