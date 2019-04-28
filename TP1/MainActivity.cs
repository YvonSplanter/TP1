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
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
            text1.Text = GetData().ToString();
        }

        public static async Task<CatalogPhone> GetData()
        {
            var client = new HttpClient();
            string response = await client.GetStringAsync("http://localhost:50629/api/phones");
            var contenue = JsonConvert.DeserializeObject<CatalogPhone>(response);
            Console.WriteLine(contenue.ToString());
            return contenue;

        }
    }
}