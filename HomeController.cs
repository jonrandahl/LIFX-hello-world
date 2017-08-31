using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LIFxMVC.Controllers
{
  public class HomeController : Controller
  {
    public async System.Threading.Tasks.Task<ActionResult> Index(string colour = "white", string power = "on")
    {
      var client = new HttpClient();

      //There are different parameters that can be passed to API. 
      var requestContent = new FormUrlEncodedContent(new[] {
        new KeyValuePair<string, string>("color", $"{colour} saturation:0.5"),
        new KeyValuePair<string, string>("power", power),
        new KeyValuePair<string, string>("brightness", "0.5"), 
        new KeyValuePair<string, string>("duration", "1") 
      }
      );

      client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["LIFX:APIKey"]);

      //call the LIFX api
      var response = await client.PutAsync("https://api.lifx.com/v1/lights/all/state", requestContent);

      // Get the response content from API
      var responseContent = response.Content;

      using (var reader = new System.IO.StreamReader(await responseContent.ReadAsStreamAsync()))
      {
        // Write the output.
        Console.WriteLine(await reader.ReadToEndAsync());
      }
      return View();
    }
  }
}