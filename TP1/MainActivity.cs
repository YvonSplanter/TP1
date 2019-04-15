using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;

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

        public async Task<string> GetData() {
            HttpClient client = new HttpClient();
            var uri = new Uri("http://localhost:50629/api/phones/1");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(uri);
            //var content =  response.Content.ReadAsStringAsync();
            var content = response.Result.RequestMessage.Content.ToString();
            return response.Result.Content.ToString();
        }
    }
}