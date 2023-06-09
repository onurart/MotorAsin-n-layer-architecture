using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketProjectClient.UI.Models;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetTopDocuments()
        {
            var query = (
                from d in _dbContext.Documents
                join c in _dbContext.Customers on d.CustomerReferance equals c.CustomerReferance
                join p in _dbContext.Products on d.ProductReferance equals p.ProductReferance
                group d by new { c.CustomerName, p.ProductName } into g
                orderby g.Sum(d => d.Quantity) descending
                select new
                {
                    CustomerName = g.Key.CustomerName.Substring(0,10),
                    ProductName = g.Key.ProductName,
                    TotalQuantity = g.Sum(d => d.Quantity)
                }
            ).Take(10);

            var result = await query.ToListAsync();
            return Json(result);
        }

        //public async Task<ActionResult<IEnumerable<object>>> GetTopDocuments()
        //{
        //    var query = (
        //        from d in _dbContext.Documents
        //        join c in _dbContext.Customers on d.CustomerReferance equals c.CustomerReferance
        //        join p in _dbContext.Products on d.ProductReferance equals p.ProductReferance
        //        group d by new { c.CustomerName, p.ProductName } into g
        //        orderby g.Sum(d => d.Quantity) descending
        //        select new
        //        {
        //            CustomerName = g.Key.CustomerName,
        //            ProductName = g.Key.ProductName,
        //            TotalQuantity = g.Sum(d => d.Quantity)
        //        }
        //    ).Take(10);

        //    var result = await query.ToListAsync();

        //    return Ok(result);
        //}



        //     public IActionResult GetTopCustomerProducts()
        //     {
        //         var query = (
        //    from d in _dbContext.Documents
        //    join c in _dbContext.Customers on d.CustomerReferance equals c.CustomerReferance
        //    join p in _dbContext.Products on d.ProductReferance equals p.ProductReferance
        //    group d.Quantity by new
        //    {
        //        d.CustomerReferance,
        //        c.CustomerName,
        //        d.ProductReferance,
        //        p.ProductName
        //    } into g
        //    orderby g.Sum() descending
        //    select new
        //    {
        //        g.Key.CustomerReferance,
        //        g.Key.CustomerName,
        //        g.Key.ProductReferance,
        //        g.Key.ProductName,
        //        TotalQuantity = g.Sum()
        //    }
        //).Take(10);

        //         var result = query.ToList();
        //         var updatedResult = query.Select(item => new
        //         {
        //             CustomerName = item.CustomerName,
        //             ProductName = item.ProductName,
        //             Quantity = item.TotalQuantity
        //         }).ToList();

        //         // Prepare data for chart
        //         var customerNames = updatedResult.Select(x => x.CustomerName).ToList();
        //         var productNames = updatedResult.Select(x => x.ProductName).ToList();
        //         var quantities = updatedResult.Select(x => x.Quantity).ToList();

        //         return Json(query);
        //     }

























        //public IActionResult GetDocumentsTopChartData()
        //{
        //    var query = _dbContext.Documents
        //    .Join(_dbContext.Documents, c => c.Id, p => p.Id, (c, p) => new { c, p })
        //    .GroupBy(x => x.c.Customer.Id)
        //    .Select(g => new
        //    {
        //        CustomerId = g.Key,
        //        TotalProducts = g.Count()
        //    })
        //    .OrderByDescending(x => x.TotalProducts)
        //    .Take(10);
        //    var result = query.ToList();
        //    ViewBag.ChartData = result; // Veriyi ViewBag içine atıyoruz

        //    return View(result);
        //}
        //public IActionResult GetDocumentsTopChartData()
        //{
        //    try
        //    {
        //        var query = _dbContext.Documents
        //            .Join(_dbContext.Documents, c => c.Id, p => p.Id, (c, p) => new { c, p })
        //            .GroupBy(x => x.c.Customer.Id)
        //            .Select(g => new
        //            {
        //                CustomerId = g.Key,
        //                TotalProducts = g.Count()
        //            })
        //            .OrderByDescending(x => x.TotalProducts)
        //            .Take(10);
        //        var result = query.ToList();
        //        ViewBag.ChartData = result; // Veriyi ViewBag içine atıyoruz

        //        return View(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata ayıklama amaçlı hatayı loglama veya konsola yazdırma
        //        Console.WriteLine(ex.ToString());
        //        throw; // Hatanın yukarıya fırlatılması
        //    }
        //}
        [HttpGet]
        //public IActionResult GetDocumentsTopChartData()
        //{
        //    var query = _dbContext.Documents
        //           .Join(_dbContext.Documents, c => c.Id, p => p.Id, (c, p) => new { c, p })
        //           .Join(_dbContext.Customers, d => d.c.Customer.Id, customer => customer.Id, (d, customer) => new { d, customer })
        //           .GroupBy(x => x.customer.Id)
        //           .Select(g => new
        //           {
        //               CustomerId = g.Key,
        //               TotalProducts = g.Count()
        //           })
        //           .OrderByDescending(x => x.TotalProducts)
        //           .Take(10);
        //    var result = query.ToList();
        //    return Json(result);
        //}


        //public IActionResult GetProductCampaignChartData()
        //{
        //    //var documents = _documentRepository.ProductCampaigns.ToList();
        //    //var chartData = documents.GroupBy(d => d.MinOrder)
        //    //                        .Select(g => new { Date = g.Key, Count = g.Count() })
        //    //                        .ToList();

        //    //return Json(chartData);
        //    //var chartData = _documentRepository.ProductCampaigns.Where(d => d.CreatedDate != null)
        //    //            .GroupBy(d => new { d.ProductGroup, Year = d.CreatedDate.Value.Year })
        //    //            .Select(g => new { ProductGroup = g.Key.ProductGroup, Year = g.Key.Year, Count = g.Min(d => d.MinOrder) })
        //    //            .ToList();
        //    //var chartData = _dbContext.ProductCampaigns.Where(d => d.CreatedDate != null)
        //    //            .GroupBy(d => new { d.ProductGroup, Year = d.CreatedDate.Value.Year })
        //    //            .Select(g => new { ProductCode = g.Key.ProductGroup, Year = g.Key.Year, Count = g.Min(d => d.MinOrder) })
        //    //            .ToList();
        //    //return Json(chartData);
        //    return View();
        //}

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
            //var documents = _dbContext.Documents.ToList();
            //var chartData = documents.GroupBy(d => d.CustomerReferance.)
            //                        .Select(g => new { Date = g.Key, Count = g.Count() })
            //                        .ToList();

            return Json(true /*chartData*/);
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