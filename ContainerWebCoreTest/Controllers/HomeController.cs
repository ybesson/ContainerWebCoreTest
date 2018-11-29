using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContainerWebCoreTest.Models;
using ContainerWebCoreTest.Services;
using StructureMap;

namespace ContainerWebCoreTest.Controllers
{
    public class HomeController : Controller
    {
        public IMyService Service { get; }
        public IContainer Container { get; }

        public HomeController(IMyService service, IContainer container)
        {
            // Service.Container = DEFAULT
            Service = service;

            // Container = DEFAULT - NESTED
            Container = container;
        }

        public IActionResult Index()
        {
            // instance.Container = DEFAULT
            Container.GetInstance<IMyService>().DoWork();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
