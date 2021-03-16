using System;
using System.Windows.Input;
using NeoStoreApp.Model.AddressModel;
using NeoStoreApp.Service.AddressDataBaseService;
using NeoStoreApp.View;
using Xamarin.Forms;
using static NeoStoreApp.Model.AddressModel.AddressModel;

namespace NeoStoreApp.ViewModel
{
    public class AddAddressPageViewModel : BindableObject
    {
        AddressDataBaseService _addressDataBaseService = new AddressDataBaseService();

        //Declaring private variable to store view data.
        private string __Adrress, __Landmark, __State, __City, __Country, __Zip = null;
        //saving Details from view
        private string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                OnPropertyChanged("Address");
            }
        }

        private string _LandMark;
        public string LandMark
        {
            get
            {
                return _LandMark;
            }
            set
            {
                _LandMark = value;
                OnPropertyChanged("LandMark");
            }
        }
        private string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }
        private string _State;
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
                OnPropertyChanged("State");
            }
        }
        private string _ZipCode;
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                _ZipCode = value;
                OnPropertyChanged("ZipCode");
            }
        }

        private string _Country;
        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
                OnPropertyChanged("Country");
            }
        }
    
        public ICommand SaveData
        {
            get
            {
                return new Command(() => {
                    //method for database call
                    SaveUserData(); 

                });

            }
        }

       async private void SaveUserData()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
          
            //saving view data to private  variable
            __Adrress = _Address;
            __Landmark = _LandMark;
            __State = _State;
            __City = _City;
            __Country = _Country;
            __Zip = _ZipCode;

           await _addressDataBaseService.SaveAddressAsync(new AddressModel
            {
                Address = __Adrress+","+__Landmark+","+__State+","+__City+"-"+__Zip+"."+__Country
                
            }) ;

           
        }
    }
}
