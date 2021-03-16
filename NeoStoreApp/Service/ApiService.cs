using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;
using NeoStoreApp.Model.ProductList;


namespace NeoStoreApp.Service
{
    class ApiService
    {
        HttpClient _client;
        // Base url of the application
        private string BaseUrl = "http://staging.php-dev.in:8844/trainingapp/api/";

        public ApiService()
        {
            _client = new HttpClient();
        }
        public string PerformPostRequest(string SubBaseUrl, Dictionary<string, string> Item)
        {
            /*  //1. Create Url for api request
              Uri Url = new Uri(BaseUrl + SubBaseUrl);

              //2. Create Content
              var Content = new FormUrlEncodedContent(Item);

              //3. Create Response
              HttpResponseMessage ResponseMsg = await Client.PostAsync(Url, Content);

              //4. Check if Response is success
              if (ResponseMsg.IsSuccessStatusCode)
              {
                  string ParsedContent = await ResponseMsg.Content.ReadAsStringAsync();
                  return ParsedContent;
              }
              else
              {
                  return null;
              }
            */

            //1. Initialize Rest Client
            var client = new RestClient(BaseUrl + SubBaseUrl);
            //2. Set Api timeout
            client.Timeout = -1;
            //3. Create Rest Request
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;

            //4. Add Params to HttpRequest
            foreach (string Key in Item.Keys)
            {
                request.AddParameter(Key, Item[Key]);
            }

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
           
            if (!string.IsNullOrEmpty(response.Content))
            {
                return response.Content;
            }


            return null;
        }
        /// <summary>
        /// this is method to perform get operation from api.
        /// </summary>
        /// <param name="SubBaseUrl"></param>
        /// <returns></returns>
        

        //Get Product List (Get Method)
        public string GetProductList( string baseUrl)
        {
            var client = new RestClient(BaseUrl+baseUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                
                return response.Content;
            }


            return null;
        }

    }
}
