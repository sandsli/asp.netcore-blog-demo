using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcore_nlog.Models;

namespace aspnetcore_nlog.Controllers
{
    public class NLogController : Controller
    {
        //定义logger接口
        private static NLog.Logger _logger;

        public NLogController()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public IActionResult Index()
        {
            _logger.Error("nlog test");
            return Content("nlog");
        }

     
    }
}
