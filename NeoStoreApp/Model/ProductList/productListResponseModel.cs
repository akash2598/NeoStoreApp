using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Model.ProductList
{
   public class  productListResponseModel
    {
       

       
            public int status { get; set; }
            public List<data> data { get; set; }
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
            public string product_images { get; set; }

        }
    
  
}
