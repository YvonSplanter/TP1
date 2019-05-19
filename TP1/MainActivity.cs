﻿using Android.App;
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
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Fill the view with API call
            var principalLayout = FindViewById<LinearLayout>(Resource.Id.layoutPrincipal);
            async Task GetData()
            {
                var client = new HttpClient();
                var uri = "http://192.168.0.160:50629/api/phones";
                var result = await client.GetStringAsync(uri);
                var catalog = JsonConvert.DeserializeObject<CatalogPhone>(result);
                foreach (var phone in catalog.Phones) {
                    var tv = new TextView(this);
                    tv.Text = $"{phone.Name} : {phone.Price}";
                    principalLayout.AddView(tv);
                }
            };
            await GetData();
        }
    }
}