using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.Login;
using NeoStoreApp.Model.ProductList;
using NeoStoreApp.Service;
using NeoStoreApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    class HomeScreenPageModel:BindableObject
    {
        
       
        // Binding productList Command to get product list from api.
       
        /// <summary>
        /// On click of chair
        /// </summary>
        public ICommand OnClickChair
        {
            get
            {

                return new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductListingPage("2", "Chair"));
                });

            }
        }

        /// <summary>
        /// On click of sofa
        /// </summary>
        public ICommand OnClickSofa
        {
            get
            {

                return new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductListingPage("3", "Sofa"));
                });

            }
        }


        /// <summary>
        /// On click of cupboard
        /// </summary>
        public ICommand OnClickBed
        {
            get
            {

                return new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductListingPage("4", "Bed"));
                });

            }
        }

        public ICommand OnClickTable
        {
            get
            {

                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductListingPage("1", "Tables"));
                });

            }

        }
        //icommand for logout
        public ICommand OnClickLogOut
        {
            get
            {

                return new Command( () =>
                {
                    App.Current.Logout();
                    //setting false after logout
                    Application.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
                });

            }

        }

        //icomaand for address page
        public ICommand OnClickAccount
        {
            get
            {

                return new Command( () =>
                {
                    Application.Current.MainPage.Navigation.PushAsync(new AddressListPage()  );
                    
                });

            }

        }
    }
}
