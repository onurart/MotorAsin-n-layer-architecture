using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

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

        public async Task<object> GetOfferList(DataSourceLoadOptions loadOptions,string dataType)
        {
            bool state = true;
            if (dataType=="0")
            {
                state = false;
            }
            var offerList = await _offerApiService.GetOfferAllAsync();
            return DataSourceLoader.Load(offerList, loadOptions);
        }
    }
}
