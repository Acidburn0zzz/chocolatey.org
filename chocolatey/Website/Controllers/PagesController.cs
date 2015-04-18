﻿using System.Web.Mvc;
using System.Web.UI;

namespace NuGetGallery
{
    public partial class PagesController : Controller
    {
        private readonly IAggregateStatsService statsSvc;

        public PagesController(IAggregateStatsService statsSvc)
        {
            this.statsSvc = statsSvc;
        }

        public virtual ActionResult Home()
        {
            return View("~/Views/Pages/Home.cshtml");
        }  
        
        public virtual ActionResult About()
        {
            return View("~/Views/Pages/About.cshtml");
        } 
        
        public virtual ActionResult Notice()
        {
            return View("~/Views/Pages/Notice.cshtml");
        }

        public virtual ActionResult Terms()
        {
            return View("~/Views/Pages/Terms.cshtml");
        }

        public virtual ActionResult Privacy()
        {
            return View("~/Views/Pages/Privacy.cshtml");
        }

        //public ActionResult Install()
        //{
        //    return File(Url.Content("~/installChocolatey.ps1"), "text/plain");
        //}

        [HttpGet]
        [OutputCache(VaryByParam = "None", Duration = 120, Location = OutputCacheLocation.Server)]
        public virtual JsonResult Stats()
        {
            var stats = statsSvc.GetAggregateStats();
            return Json(new
            {
                Downloads = stats.Downloads.ToString("n0"),
                UniquePackages = stats.UniquePackages.ToString("n0"),
                TotalPackages = stats.TotalPackages.ToString("n0")
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
