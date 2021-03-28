using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            searchhandler.Load(MyList);
            mycosmestics = searchhandler.LayData();
        }
        List<String> MyList = new List<string>();
        List<Cosmestics> mycosmestics = new List<Cosmestics>();
        ItemSearchHandler searchhandler = new ItemSearchHandler();
            private async void Search_TextChange(object sender, TextChangedEventArgs e)
        {
            var SearchResult = MyList.Where(c =>
            {
                string text1 = Search.Text;
                return c.ToLower().Contains(text1.ToLower());
            });
            Coll.ItemsSource = SearchResult;
        }

        
    }
}
