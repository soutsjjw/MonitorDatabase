using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MonitorDatabase.Hubs;
using MonitorDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChangeNotify _changeNotify;
        private readonly IHubContext<DBHub> _hubContext;
        private readonly IConfiguration _Configuration;

        public HomeController(ILogger<HomeController> logger, IChangeNotify changeNotify, IHubContext<DBHub> hubContext, IConfiguration Configuration)
        {
            _logger = logger;
            _changeNotify = changeNotify;
            _hubContext = hubContext;
            _Configuration = Configuration;

            _changeNotify.Start(_hubContext);
        }

        public IActionResult Index()
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("DefaultConnection")))
            {
                var userInfos = connection.Query<UserInfo>("SELECT * FROM [UserInfos]").ToList();

                return View(userInfos);
            }
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
