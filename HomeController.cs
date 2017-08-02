using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Net.Http;


namespace LIFXapp.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index(string colour = "white")
        {
            var client = new HttpClient();

            //There are different parameters that can be passed to API. Just the colour for now.
            var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("color", colour)});

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["LIFX:APIKey"]);
            
            //call the LIFX api
            HttpResponseMessage response = await client.PutAsync(
                "https://api.lifx.com/v1/lights/all/state", requestContent);

            // Get the response content from API
            HttpContent responseContent = response.Content;
            
            using (var reader = new System.IO.StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                Console.WriteLine(await reader.ReadToEndAsync());
            }
            return View();
        }
    }
}