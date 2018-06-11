using IntegerArrayGrouper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegerArrayGrouper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ViewModel());
        }

        [HttpPost]
        public ActionResult Index(ViewModel model)
        {
            var helper = new IntegerArrayHelper();

            if(!helper.Validate(model.Input))
            {
                model.IsError = true;
                model.Output = "Invalid input format.";
                return View(model);
            }

            var input = helper.Parse(model.Input);
            var output = input.GroupBy(x => x).Where(g => g.Count() >= 3).Select(x => x.Key).OrderByDescending(x => x);
            model.Output = helper.Format(output);

            return View(model);
        }
    }
}