using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Conti.Massimiliano._5I.XMLReadWrite
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersoneXLMWeb()
        {
            string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");
            XElement data = XElement.Load(nomeFile);
            var persone = (from l in data.Elements("Persona") select new Persona(l)).ToList();

            return View(persone);
        }

        public ActionResult XMLReadWrite()
        {
            string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");

            var p = new Persone(nomeFile);
            p.Aggiungi();
            return View(p);
        }
    }
}