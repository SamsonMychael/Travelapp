using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Travelapp.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class newPage : TabbedPage
    {
        public newPage()
        {
            InitializeComponent();
        }

        private void addbutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add());
        }

        
    }
}