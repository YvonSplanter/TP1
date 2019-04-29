using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using TP1.Model;
using Newtonsoft.Json;

namespace TP1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
            //var catalog = GetData();
            text1.Click += async delegate
            {
                var client = new HttpClient();
                var uri = "http://192.168.0.159:50629/api/phones";
                var result = await client.GetStringAsync(uri);
                var catalog = JsonConvert.DeserializeObject<CatalogPhone>(result);
                text1.Text = $"{catalog.Phones[0].ID} : {catalog.Phones[0].Name}";
            };
            
            //text1.Text = $"condition ? {0} : {1}";
        }

        public static async Task<CatalogPhone> GetData()
        {
            var client = new HttpClient();
            string response = "";
            try {
                 response = await client.GetStringAsync("http://192.168.0.159:50629/api/phones");
            }
            catch(Exception e) { Console.WriteLine(e);Console.ReadKey(); }
            
            var contenue = JsonConvert.DeserializeObject<CatalogPhone>(response);
            Console.WriteLine($"{contenue.Phones[0].ID} : {contenue.Phones[0].Name}");
            return contenue;

        }
    }
}