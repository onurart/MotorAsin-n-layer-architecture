using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Offer;

namespace MotorAsinBasketProjectClient.UI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OfferController : Controller
    {
        private readonly OfferApiService _offerApiService;

        public OfferController(OfferApiService offerApiService)
        {
            _offerApiService = offerApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<object> GetOfferList(DataSourceLoadOptions loadOptions,OfferListPramertDto offer)
        {
            var offerList = await _offerApiService.GetOfferAllAsync();
            return DataSourceLoader.Load(offerList, loadOptions);
        }
    }
}
