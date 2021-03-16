using NeoStoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoStoreApp.View.HomeScreenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainHomeScreen : ContentPage
    {
        public MainHomeScreen()
        {
            InitializeComponent();

           
            
            //Binding ViewModel
           
            BindingContext = new MainHomeScreenViewModel();
            
            var list = new List<mode>()
            {
                new mode()
                {
                    img="https://www.royaloakindia.com/uploads/Lifestyle800X50081.jpg"
                },
                new mode()
                {
                    img="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new mode()
                {
                    img="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new mode()
                {
                    img="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new mode()
                {
                    img="https://thumbs.dreamstime.com/b/urban-jungle-trendy-living-room-interior-white-couch-black-knot-pillow-wooden-furniture-copy-space-empty-wall-174228512.jpg"
                }
            };
            TheCarousel.ItemsSource = list;
            
        }

      
      
     
    }
}