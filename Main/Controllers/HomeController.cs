using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Main.Models;
using Newtonsoft.Json;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<BookModel> people = new List<BookModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            people = JsonConvert.DeserializeObject<List<BookModel>>(readWrite.Read("books.json","data"));

            return View(people);
            
        }
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
    public class JSONReadWrite
    {
        public JSONReadWrite() { }

        public string Read(string fileName, string location)
        {
           
            string root = "App_Data";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                root,
                location,
                fileName);

            string jsonResult;
            
            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }


    }
}