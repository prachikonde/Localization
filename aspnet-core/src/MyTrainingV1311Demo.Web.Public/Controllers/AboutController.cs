﻿using Microsoft.AspNetCore.Mvc;
using MyTrainingV1311Demo.Web.Controllers;

namespace MyTrainingV1311Demo.Web.Public.Controllers
{
    public class AboutController : MyTrainingV1311DemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}