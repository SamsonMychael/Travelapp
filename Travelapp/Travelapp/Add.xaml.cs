using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travelapp.Model;
using SQLite;

namespace Travelapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage 
    {
        public Add()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            post post = new post()
            {
                Experience =  expretienceEntry.Text
            };

            using (SQLiteConnection sam = new SQLiteConnection(App.Databaselocation)) 
            {
                sam.CreateTable<post>();
                int rows = sam.Insert(post);
       
                if (rows > 0)
                  await  DisplayAlert("Success", " Experience  successfully inserted", "ok");
                else
                  await  DisplayAlert("Failure", " Experience failed to be inserted", "ok");
            }

        }
    }
}