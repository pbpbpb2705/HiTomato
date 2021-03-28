using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(itemname), nameof(itemname))]
    public partial class ItemDetails : ContentPage
    {
        public string itemname
        {
            set
            {
                LoadItem(value);


                async void LoadItem(string itemname)
                {
                    ItemSearchHandler search = new ItemSearchHandler();
                    List<Cosmestics> myitem = search.LayData();
                    try
                    {
                        Cosmestics chosen = myitem.Where(c =>
                        {
                            string findname = itemname;
                            return c.name.ToLower().Contains(findname.ToLower());

                        }).FirstOrDefault();
                        // Retrieve the note and set it as the BindingContext of the page.

                        BindingContext = chosen;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed to load product");
                    }
                }
            }
            
        }
        async void LoadItem(string name)
        {

        }
        public ItemDetails()
        {
            InitializeComponent();

        }

        
    }
}