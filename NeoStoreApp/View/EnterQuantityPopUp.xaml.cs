using System;
using System.Collections.Generic;
using NeoStoreApp.Model.ProductDetail;
using NeoStoreApp.ViewModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NeoStoreApp.View
{
    public partial class EnterQuantityPopUp : PopupPage
    {
        private productDetailResponseModel _ProductDetail = new productDetailResponseModel();
        public EnterQuantityPopUp(productDetailResponseModel detail,string ImageSource)
        {
            InitializeComponent();
            _ProductDetail = detail;
            ProductImage.Source = ImageSource;
            BindingContext = new EnterQuantityPopUpViewModel(_ProductDetail);
            
    }
        
       
}
}
