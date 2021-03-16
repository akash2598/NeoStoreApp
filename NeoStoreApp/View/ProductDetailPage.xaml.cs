using NeoStoreApp.Model.ProductDetail;
using NeoStoreApp.Model.ProductList;
using NeoStoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//ceating data object from productDeailResponsemodel
using dataProduct = NeoStoreApp.Model.ProductList.data;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
       

        private dataProduct SelectedItem = null;

        //creating object of productdetailviewmodel to it with this page.
        private ProductDetailViewModel viewModel = null;

        public ProductDetailPage(dataProduct Item, string categoryName)
        {
            InitializeComponent();
            SelectedItem = Item;
            Category_Name.Text = categoryName;
            viewModel = new ProductDetailViewModel(SelectedItem);
            BindingContext = viewModel;


        }
       



    }
}