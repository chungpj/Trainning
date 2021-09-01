// Copyright (c) ChungNA - 2020 All Rights Reserved
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DependencyInjection.Test.Models;
using DependencyInjection.Test.Services;

namespace DependencyInjection.Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseService _baseService;
        private readonly IMyTransientService _transientService;
        private readonly IMyScopedService _scopedService;
        private readonly IMySingletonService _singletonService;

        public HomeController(ILogger<HomeController> logger, 
            BaseService operationService,
            IMyTransientService transientOperation,
            IMyScopedService scopedOperation,
            IMySingletonService singletonOperation)
        {
            _logger = logger;
            _baseService = operationService;
            _transientService = transientOperation;
            _scopedService = scopedOperation;
            _singletonService = singletonOperation;
        }

        public IActionResult Index()
        {
            // ViewBag contains controller-requested services
            ViewBag.Transient = _transientService.GuidId;
            ViewBag.Scoped = _scopedService.GuidId;
            ViewBag.Singleton = _singletonService.GuidId;

            // Base service has its own requested services
            ViewBag.OwnService = _baseService;
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
