using System;
namespace NeoStoreApp.Model.RateModel
{
    public class RateResponseModel
    {
        public int id { get; set; }
        public int product_category_id { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public int cost { get; set; }
        public double rating { get; set; }
        public int view_count { get; set; }
        public string description { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
    }

}
