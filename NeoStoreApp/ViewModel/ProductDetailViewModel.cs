using System;
using System.Collections.Generic;
using System.Text;
using dataProduct = NeoStoreApp.Model.ProductList.data;

using Xamarin.Forms;
using NeoStoreApp.Service.ProductDetail;
using NeoStoreApp.Model.ProductDetail;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using NeoStoreApp.View;

namespace NeoStoreApp.ViewModel
{
    class ProductDetailViewModel : BindableObject
    {
        int Id;
        //object of list  response model.
        private dataProduct SelectedProduct = null;
        private productDetailService _productDeatilService = new productDetailService();
        //object of deatil response model.
        private productDetailResponseModel _dataDetail = null;
        public productDetailResponseModel dataDetail
        {
            get { return _dataDetail; }
            set
            {
                _dataDetail = value;
                OnPropertyChanged("dataDetail");
            }

        }

        //Getting image source from selected Item from collection view selectedItem method.
        private product_images _SelectedImageItem;
        
        public product_images SelectedImageItem
        {
            get
            {
                return _SelectedImageItem;
            }
            set
            {
                _SelectedImageItem = value;
                OnPropertyChanged("SelectedImageItem");

            }
        }
        //setting image source for image from collection view
        private string _ImageSource;
        public string ImageSource
        {
            get
            {
                return _ImageSource;
            }
            set
            {
                _ImageSource = value;
                OnPropertyChanged("ImageSource");

            }
        }

       
        //viewmodel Constructor
        public ProductDetailViewModel(dataProduct SelectedItem) {
            SelectedProduct = SelectedItem;
            

            //1. Get the prodict id
             Id = SelectedProduct.id;
            //setting Image source from api source.
             ImageSource = SelectedProduct.product_images;
           // ImageSource= "https://www.royaloakindia.com/uploads/Lifestyle800X50081.jpg";
            //2. Call api method
            getDetail();
           
            
        }
        //method for api call.
        private void getDetail()
        {
            var response = _productDeatilService.getDetail(Id);
            //3. After success bind data to view
            dataDetail = response;

        }

        //Binding selection changed command from view
        public ICommand SelectedTagChanged
        {
            get
            {
                
                
                return new Command(() =>
                {
                    ChangeImage();
                    
                });
            }
            
        }

        private void ChangeImage()
        {
            ImageSource = SelectedImageItem.image;
            
             
        }

        //Method to open popUp
        [Obsolete]
        public ICommand OnByNowClick
        {
            get
            {
                return new Command(async () => {

                    await PopupNavigation.PushAsync(new EnterQuantityPopUp(dataDetail,ImageSource));


                });
            }

        }

        [Obsolete]
        public ICommand OnRateClick
        {
            get
            {
                return new Command(async () => {

                    await PopupNavigation.PushAsync(new RatingPopUp(dataDetail, ImageSource));


                });
            }

        }

    }
}
