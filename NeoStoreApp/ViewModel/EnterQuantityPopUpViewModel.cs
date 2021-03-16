using System;
using System.Windows.Input;
using NeoStoreApp.Model.ProductDetail;
using NeoStoreApp.View;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    public class EnterQuantityPopUpViewModel:BindableObject
    {
       
        //creating binding varible
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
        public EnterQuantityPopUpViewModel(productDetailResponseModel detail)
        {
         
            dataDetail = detail;

        }
      

        public ICommand OpenAddressList
        {
            get
            {
                return new Command(async () => {

                    await PopupNavigation.Instance.PopAllAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new AddressListPage());


                });
            }

        }

    }
}
