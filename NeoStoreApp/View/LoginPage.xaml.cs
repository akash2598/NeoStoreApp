using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NeoStoreApp.ViewModel;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //Bind the login view model with login page.
            BindingContext = new LoginPageViewModel();
           


        }

        
        
    }
}