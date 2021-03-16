using System;
using System.Windows.Input;
using NeoStoreApp.Model.ProductDetail;
using NeoStoreApp.Model.RateModel;
using NeoStoreApp.Service.ProductRateService;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    public class RatingPopUpViewModel: BindableObject

    {
        RateService rateService = new RateService();

        //binding rate value
        private string _RateValue = null;
        public string RateValue
        {
            get { return _RateValue; }
            set
            {
                _RateValue = value;
                OnPropertyChanged("RateValue");
            }
        }

        //binding api data to view
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

        public RatingPopUpViewModel(productDetailResponseModel detail)
        {
            dataDetail = detail;
        }

        //method for sending rateing value to api
        public ICommand GiveRating
        {
            get
            {


                return new Command(() =>
                {
                    RatingCall();

                });
            }

        }
        //call api for giving rate
       async private void RatingCall()
        {
            string RatingValue = _RateValue;

            int ProductId = dataDetail.data.id;

            RateRequestModel request = new RateRequestModel();
            request.product_id = ProductId;
            request.rating = RatingValue;
            var Response = rateService.SetRating(request);
            await Application.Current.MainPage.DisplayAlert("Alert", Response.user_msg, "OK");
            await PopupNavigation.Instance.PopAllAsync();


        }
    }
}
