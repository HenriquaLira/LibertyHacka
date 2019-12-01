using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using JsonRes = PainelAnalyse.Models;

namespace Painel_de_Verificação.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address=Rua%20Francisco%20Rebelo%20321&key=AIzaSyAlZA6KjskEkGM7m7z0SsfKAE6kGLucTWA"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            JsonRes.JsonResult jsonResults = JsonConvert.DeserializeObject<JsonRes.JsonResult>(jsonString);
            Tuple<double, double> latLong = _returnLongLat(jsonResults);

            ViewData["Message"] = String.Format("https://maps.googleapis.com/maps/api/streetview?size=600x300&location={0},{1}&heading=151.78&pitch=-0.76&key=AIzaSyAlZA6KjskEkGM7m7z0SsfKAE6kGLucTWA", latLong.Item1, latLong.Item2);

            return View();
        }

        [HttpPost]
        public ActionResult Index(string tipo, string endereco, string numero, string CEP)
        {

            string enderecoFormatado = _formatarEndereco(tipo, endereco, numero, CEP);

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=AIzaSyAlZA6KjskEkGM7m7z0SsfKAE6kGLucTWA", enderecoFormatado));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            JsonRes.JsonResult jsonResults = JsonConvert.DeserializeObject<JsonRes.JsonResult>(jsonString);
            Tuple<double, double> latLong = _returnLongLat(jsonResults);

            ViewData["Message"] = String.Format("https://maps.googleapis.com/maps/api/streetview?size=600x300&location={0},{1}&heading=151.78&pitch=-0.76&key=AIzaSyAlZA6KjskEkGM7m7z0SsfKAE6kGLucTWA", latLong.Item1, latLong.Item2);
            ViewData["linkMaps"] = String.Format("https://www.google.com.br/maps/place/{0}", enderecoFormatado);

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

        private Tuple<double, double> _returnLongLat(JsonRes.JsonResult jsonResults)
        {
            Tuple<double, double> tuple = 
                new Tuple<double, double>(jsonResults.Results[0].Geometry.Location.Lat, 
                jsonResults.Results[0].Geometry.Location.Lng);

            return tuple;
        }
        private string _formatarEndereco(string tipo, string endereco, string numero, string CEP)
        {
            string enderecoFormatado = String.Format("{0}%20{1}%20{2}%20{3}", tipo, endereco, numero, CEP);

            return enderecoFormatado;
        }
    }
}