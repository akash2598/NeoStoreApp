using NeoStoreApp.Model.ProductList;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Service.ProductDetail
{
    class ProductListservice
    {
        private ApiService apiService = new ApiService();
        public productListResponseModel getProductList(string CategoryId)
        {
            //storing Id Value
            string id = string.IsNullOrEmpty(CategoryId) ? "1" : CategoryId;

   
            //Generating BaseUrl
            string SubBaseUrl = "products/getList?product_category_id=" + id + "&limit=10&page=1";
            
            var Response = apiService.GetProductList(SubBaseUrl);
            var Result = JsonConvert.DeserializeObject<productListResponseModel>(Response);
            return Result;
        }
    }
}
