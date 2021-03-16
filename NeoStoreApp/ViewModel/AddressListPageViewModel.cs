using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using NeoStoreApp.Model.AddressModel;
using NeoStoreApp.Service.AddressDataBaseService;
using NeoStoreApp.View;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    public class AddressListPageViewModel:BindableObject

    {
        
        AddressDataBaseService DataBaseService = new AddressDataBaseService();

        private List<AddressModel>  _ItemSource;
        public List<AddressModel> ItemSource
        {
            get
            {
                return _ItemSource;
            }
            set
            {
                _ItemSource = value;
                OnPropertyChanged("Itemsource");
            }
        }



        private bool _IsRun;
        public bool IsRun
        {
            get
            {
                return _IsRun;
            }
            set
            {
                _IsRun = value;
                OnPropertyChanged("IsRun");
            }
        }




        //storing Selected address from list to be deleted
        private AddressModel _SelectedAddress;
        public AddressModel SelectedAddress
        {
            get
            {
                return _SelectedAddress;
            }
            set
            {
                _SelectedAddress = value;
                OnPropertyChanged("SelectedAddress");
               
            }
        }
            
        //command to add new addres to list
        public ICommand AddNewAddress
        {
            get
            {
                return new Command(() => {
                    Application.Current.MainPage.Navigation.PushAsync(new AddAddressPage());

                });

            }
        }
        //command to delete address
        public ICommand DeleteAddress
        {
            get
            {
                return new Command(() => {
                    DeleteSelectedAddress();

                });

            }
        }

       




        async private  void DeleteSelectedAddress()
        {
            IsRun = true;
            var address = _SelectedAddress;
            try {
                if (address != null)
                {
                    await DataBaseService.DeleteNoteAsync(address);
                    

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //code to set list source after deleting item from list
            List< AddressModel> respone = await DataBaseService.GetDataAsync();
            ItemSource = respone;
            
            
            IsRun = false;
           
        }
    }
}
