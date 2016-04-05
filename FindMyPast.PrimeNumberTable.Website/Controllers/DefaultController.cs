using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindMyPast.PrimeNumberTable.Website.Models;

namespace FindMyPast.PrimeNumberTable.Website.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Table(int dimension)
        {
            
            var tableGenerator = new TableGenerator(new PrimeNumberValidator());
            var table = tableGenerator.GenerateWithDimensionOf(dimension);

            var model = TableModel.From(table);

            return View(model);
        }

    }
}