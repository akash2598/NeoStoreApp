using NeoStoreApp.Model.ProductDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Service.ProductDetail
{
    class productDetailService
    {
        private ApiService apiService = new ApiService();
        public productDetailResponseModel getDetail(int id)
        {

            string SubBaseUrl = "products/getDetail?product_id="+id;
            var Result = apiService.GetProductList(SubBaseUrl);
            try
            {
                var Response = JsonConvert.DeserializeObject<productDetailResponseModel>(Result);
                return Response;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}
