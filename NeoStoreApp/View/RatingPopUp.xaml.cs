using System;
using System.Collections.Generic;
using NeoStoreApp.Model.ProductDetail;
using NeoStoreApp.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace NeoStoreApp.View
{
    public partial class RatingPopUp : PopupPage
    {
        private productDetailResponseModel _ProductDetail = new productDetailResponseModel();
        public RatingPopUp(productDetailResponseModel detail, string ImageSource)
        {
            InitializeComponent();
            _ProductDetail = detail;
            ProductImage.Source = ImageSource;
            BindingContext = new RatingPopUpViewModel(_ProductDetail);
            
        }
    }
}
