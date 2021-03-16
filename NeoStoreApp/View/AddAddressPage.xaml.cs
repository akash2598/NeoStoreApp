using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoStoreApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAddressPage : ContentPage
    {
        public AddAddressPage()
        {
            InitializeComponent();
            BindingContext = new AddAddressPageViewModel();
        }
    }
}