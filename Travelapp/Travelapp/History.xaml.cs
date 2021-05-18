using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelapp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Travelapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }

       /* protected override void OnAppearing()
        {
            base.OnAppearing();

           using (SQLiteConnection cnn = new SQLiteConnection(App.Databaselocation))
            {
                cnn.CreateTable<post>();
                var posts = cnn.Table<post>().ToList();
                PostListView.ItemsSource = posts;
            }
        }*/


    }
}