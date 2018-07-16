using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActionTotalTime.Models;

namespace ActionTotalTime.Controllers
{
    [ServiceFilter(typeof(TimerFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(GenerateWaitTime() * 1000);
            return View();
        }

        public IActionResult About()
        {
            System.Threading.Thread.Sleep(GenerateWaitTime() * 1000);
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            System.Threading.Thread.Sleep(GenerateWaitTime() * 1000);
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            System.Threading.Thread.Sleep(GenerateWaitTime() * 1000);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [IgnoreAction]
        public IActionResult Report()
        {
            using (ActionContext dbContext = new ActionContext())
            {
                List<ReportModel> viewModel = new List<ReportModel>();
                dbContext.ActionPerformance.GroupBy(
                res => new { Name = res.ControllerName + '/' + res.ActionName })
                .Select(g => new
                {
                    Name = g.Key.Name,
                    TotalSeconds = g.Average(p => p.TotalSeconds)
                }).ToList()
                .ForEach(row =>
                {
                    viewModel.Add(new ReportModel() { Name = row.Name, TotalSeconds = row.TotalSeconds });
                });

                return View(viewModel);
            }
        }
        [IgnoreAction]
        public IActionResult Detail(string ActionName)
        {
            ViewBag.Action=ActionName.Replace("_","/");
            string action = ActionName.Split('_')[1];
            string controller = ActionName.Split('_')[0];
            List<DetailModel> viewModel = new List<DetailModel>();
            using (ActionContext dbContext = new ActionContext())
            {
                dbContext.ActionPerformance.Where(res => res.ActionName == action && res.ControllerName == controller).Select(lis => new
                {
                    Name = lis.ControllerName + '/' + lis.ActionName,
                    TotalSeconds = lis.TotalSeconds,
                    CreatedDate = lis.CreatedDate
                }).Take(10).OrderByDescending(fn => fn.CreatedDate).ToList().ForEach(row =>
                  {
                      viewModel.Add(new DetailModel() { Name = row.Name, TotalSeconds = row.TotalSeconds, CreatedDate = row.CreatedDate });
                  });
            }
            return View(viewModel);
        }
        public int GenerateWaitTime()
        {
            Random rnd = new Random();
            return rnd.Next(1, 5);
        }
    }
}
