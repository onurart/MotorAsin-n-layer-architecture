using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketProjectClient.UI.Models;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using System.Diagnostics;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppDbContext _dbContext;

        public HomeController(AppDbContext documentRepository)
        {
            _dbContext = documentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProductCampaignChartData()
        {
            //var documents = _documentRepository.ProductCampaigns.ToList();
            //var chartData = documents.GroupBy(d => d.MinOrder)
            //                        .Select(g => new { Date = g.Key, Count = g.Count() })
            //                        .ToList();

            //return Json(chartData);
            //var chartData = _documentRepository.ProductCampaigns.Where(d => d.CreatedDate != null)
            //            .GroupBy(d => new { d.ProductGroup, Year = d.CreatedDate.Value.Year })
            //            .Select(g => new { ProductGroup = g.Key.ProductGroup, Year = g.Key.Year, Count = g.Min(d => d.MinOrder) })
            //            .ToList();
            var chartData = _dbContext.ProductCampaigns.Where(d => d.CreatedDate != null)
                        .GroupBy(d => new { d.ProductGroup, Year = d.CreatedDate.Value.Year })
                        .Select(g => new { ProductCode = g.Key.ProductGroup, Year = g.Key.Year, Count = g.Min(d => d.MinOrder) })
                        .ToList();
            return Json(chartData);
        }

        //public IActionResult GetDocumentChartData()
        //{
        //    var documents = _documentRepository.Documents.ToList();
        //    var chartData = documents.GroupBy(d => d.CustomerReferance)
        //                            .Select(g => new { Date = g.Key, Count = g.Count() })
        //                            .ToList();

        //    return Json(chartData);
        //}

        public IActionResult GetDocumentChartData()
        {
            var documents = _dbContext.Documents.ToList();
            var chartData = documents.GroupBy(d => d.CustomerReferance.Value)
                                    .Select(g => new { Date = g.Key, Count = g.Count() })
                                    .ToList();

            return Json(chartData);
        }


        //public IActionResult GetProductChartData()
        //{
        //    var chartData = _dbContext.Customers
        //    .GroupBy(p => p.Id)
        //    .Select(g => new
        //    {
        //        ProductCode = g.Key,
        //        ProductGroup1 = g.Sum(p => p.CreatedDate),
        //        ProductGroup2 = g.Sum(p => p.ProductGroup2),
        //        ProductGroup3 = g.Sum(p => p.ProductGroup3),
        //        ProductGroup4 = g.Sum(p => p.ProductGroup4)
        //    })
        //    .ToList();

        //    return Json(chartData);
        //}

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