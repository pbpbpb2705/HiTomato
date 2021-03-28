using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App2
{
    public class ItemSearchHandler : SearchHandler
    {
        public Type SelectedItemNavigationTarget { get; set; }

        public class KetQua
        {
            [JsonProperty("DS_KetQua")]
            public Cosmestics Cosmestics { get; set; }
        }

        public static string DoiString(string x)
        {
            string ans = x.Replace(' ', '+');
            return ans;
        }

        public List<Cosmestics> LayData()
        {
            var w = new WebClient();

            var json_data = string.Empty;

            var Link = "https://skincare-api.herokuapp.com/products";

            json_data = w.DownloadString(Link);
            var answer = JsonConvert.DeserializeObject<List<Cosmestics>>(json_data);
            return answer;
        }

        public void Load(List<string> MyList)
        {
            List<Cosmestics> SearchAns = LayData();
            int spt = SearchAns.Count;
            for (int i = 0; i < spt; ++i)
            {
                MyList.Add(SearchAns[i].name);
            }

        }

        /*protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation completed
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"{nameof(ItemDetails)}?{nameof(ItemDetails.itemid)}={((Cosmestics)item).id}");
        }*/

        /*string GetNavigationTarget()
        {
            //return (Shell.Current as ItemDetails).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }*/
    }
}
