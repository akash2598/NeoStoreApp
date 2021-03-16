using NeoStoreApp.Model.ProductList;
using NeoStoreApp.Service.ProductDetail;
using NeoStoreApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    class ProductListingPageViewModel: BindableObject
    {
        //Creating object of list service to access getlist method
        private ProductListservice _ProductListservice = new ProductListservice();
        //BInding Response Model to view.
        private productListResponseModel _Product_List;
        //saving Category name in variable
        public string Category;
       
        public productListResponseModel Product_List
        {
            get
            {
                return _Product_List;
            }
            set
            {
                _Product_List = value;
            }
        }

        //Getting Selected Item and storing
        private data _SelectedProduct;
        public data SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                if (value != null)
                {
                    _SelectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
                    UserSelectedProductDetail();

                }
            }
        }

        public ProductListingPageViewModel(string ProductId,string CategoryName)//view model constructor.
        {

            string ProductCategory = ProductId;

            Category = CategoryName;
            //Calling Method to get product List api Call.
            GetList(ProductCategory);
           
        }

        //method to get data from api
        public void GetList(string Id)
        {
            var Result = _ProductListservice.getProductList(Id);
            Product_List = Result;
            
        }

        //method to send id to productdetail page.
        private void UserSelectedProductDetail()
        {
            Device.BeginInvokeOnMainThread(() => {
                Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage(_SelectedProduct, Category));
            });

        }


    }
}
