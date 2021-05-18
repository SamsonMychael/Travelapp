using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Travelapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginbuton_Clicked(object sender, EventArgs e)
        {
            bool isemailEntry = string.IsNullOrEmpty(emailEntry.Text);
            bool ispasswordEntry = string.IsNullOrEmpty(passwordEntry.Text);

            if (isemailEntry || ispasswordEntry)
            {
                
            }
            else
                Navigation.PushAsync(new newPage());
       }

      

    }
}
