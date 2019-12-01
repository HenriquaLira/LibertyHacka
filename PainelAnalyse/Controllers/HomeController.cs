using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Painel_de_Verificação.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address=Rua%20Doutor%20Gentil%20Leite%20Martins%20152&key=AIzaSyAlZA6KjskEkGM7m7z0SsfKAE6kGLucTWA"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            //Results results = JsonConvert.DeserializeObject<Results>(jsonString);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    //[J("status")] (Description = "results")]
    //public class Results
    //{
    //    [JsonProperty(PropertyName = "formatted_address")]
    //    public string formatted_address { get; set; }
    //}
}