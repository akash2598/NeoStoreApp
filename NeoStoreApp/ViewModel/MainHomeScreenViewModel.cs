using NeoStoreApp.Model.Base;
using NeoStoreApp.Model.ProductList;
using NeoStoreApp.Service;
using NeoStoreApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using NeoStoreApp.View.HomeScreenPages;
using NeoStoreApp.Service.ProductDetail;

namespace NeoStoreApp.ViewModel
{
    class MainHomeScreenViewModel : BindableObject
    {

        
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
    }
    }
