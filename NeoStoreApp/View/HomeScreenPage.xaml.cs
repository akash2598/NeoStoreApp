using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.Login;
using NeoStoreApp.View.HomeScreenPages;
using NeoStoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoStoreApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeScreenPage : MasterDetailPage
    {
        
        public HomeScreenPage()
        {
            InitializeComponent();
          
            BindingContext = new HomeScreenPageModel();
            NavigationPage.SetHasNavigationBar(this, false);
           
         ///  BindingContext = new MainHomeScreenViewModel();
            //sets first page of detai to main_home_screen
           Detail = new NavigationPage(new MainHomeScreen())
            {
               
               BarBackgroundColor = Color.FromHex("#e91c1a"),
                
                
                
            };
            IsPresented = false;

        }

        //do logot
        public void LogOut(object sender ,EventArgs e)
        {
            App.Current.Logout();
            //setting false after logout
            Application.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
        }

        
    }
}