using GFT_Test.Common;
using GFT_Test.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Puzzel_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Puzzel puzzel = null;

            puzzel = Session["Puzzel"] as Puzzel;

            if (puzzel == null)
            {
                puzzel = new Decypher().GetsWordPuzzel();
                Session.Add("Puzzel", puzzel);
            }

            ViewBag.Rows = puzzel.matrix.GetLength(0);
            ViewBag.Columns = puzzel.matrix.GetLength(1);

            return View(puzzel);
        }

        public ActionResult Solve()
        {
            Puzzel puzzel = Session["Puzzel"] as Puzzel;

            puzzel.puzzelSolutions = new SolvePuzzel().FindWords(puzzel.matrix);

            return RedirectToAction("Index");
        }

        public FileResult Download()
        {
            Puzzel puzzel = Session["Puzzel"] as Puzzel;

            if (puzzel.puzzelSolutions == null || puzzel.puzzelSolutions.Count == 0)
                puzzel.puzzelSolutions = new SolvePuzzel().FindWords(puzzel.matrix);

            string solutionJson = JsonConvert.SerializeObject(puzzel.puzzelSolutions);

            string filename = "solution.json";

            var byteArray = Encoding.ASCII.GetBytes(solutionJson);
            return File(byteArray, System.Net.Mime.MediaTypeNames.Text.Plain, filename);
        }
    }
}