using NeoStoreApp.Model.ProductList;
using NeoStoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListingPage : ContentPage
    {

        
        private string CategoryName;


        public ProductListingPage(String id,string productName)
        {
            InitializeComponent();

          
            
            //setting Bar background Color
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e91c1a");


            //setting product Id
            string ProductId = id;
            //Setting Category Name
            Product_Category.Text = productName;
            CategoryName = productName;
            BindingContext = new ProductListingPageViewModel(ProductId,CategoryName);


        }

       
        
    }
}