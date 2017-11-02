using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http;

using Newtonsoft.Json;

namespace edisonNativeApp
{
    public partial class edisonNativeAppPage : ContentPage
    {
        public edisonNativeAppPage()
        {
            InitializeComponent();
        }

        // ボタンメソッド
        public async void getSensors(object sender, System.EventArgs e)
        {
            HttpClient client;
            client = new HttpClient();
            var api_uri = "xxxxxxx";
            var uri = new Uri(api_uri);

            // HTTPリクエスト
            var response = await client.GetAsync(uri);
            //System.Diagnostics.Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //System.Diagnostics.Debug.WriteLine(content);
                var sensors = JsonConvert.DeserializeObject<Sensor>(content);
                System.Diagnostics.Debug.WriteLine(sensors.Temp);

                this.te.Detail = sensors.Temp.ToString();
                this.hu.Detail = sensors.Humidity.ToString();
                this.pr.Detail = sensors.Presence ? "いる" : "いない";

            }
        }
    }
}
