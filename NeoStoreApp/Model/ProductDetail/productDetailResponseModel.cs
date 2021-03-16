using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Model.ProductDetail
{
    public class  productDetailResponseModel
    {
        public int status { get; set; }
        public data data { get; set; }
    }
    public class data
    {
        public int id { get; set; }
        public int product_category_id { get; set; }
        public int cost { get; set; }
        public int rating { get; set; }
        public int view_count { get; set; }

        public string name { get; set; }
        public string producer { get; set; }
        public string description { get; set; }
        public string created { get; set; }
        public string modified { get; set; }

        public List<product_images> product_Images { get; set; }

    }

    public class product_images
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string image { get; set; }

        public string created { get; set; }
        public string modified { get; set; }
    }
  }
