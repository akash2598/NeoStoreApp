using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NeoStoreApp;
using NeoStoreApp.Service.AddressDataBaseService;
using NeoStoreApp.ViewModel;
using NeoStoreApp.Model.AddressModel;
using System.Windows.Input;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressListPage : ContentPage
    {
        AddressDataBaseService _addressDataBaseService = new AddressDataBaseService();

        
        public AddressListPage()
        {
            InitializeComponent();
            //setting barbackground color
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e91c1a");

            BindingContext = new AddressListPageViewModel();

           


        }



       protected override async void OnAppearing()
        {
             base.OnAppearing();
            lst.ItemsSource = await _addressDataBaseService.GetDataAsync();
            
           
        }

        

    }
}