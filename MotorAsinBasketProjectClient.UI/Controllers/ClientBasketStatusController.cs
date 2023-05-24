using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientBasketStatusController : Controller
    {
        private readonly ClientBasketStatusApiService _apiService;

        public ClientBasketStatusController(ClientBasketStatusApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<object> GetBasketStatusList(DataSourceLoadOptions loadOptions, BasketStatusListParameterDto dto)
        {
            var productCampaingApiService = await _apiService.GetProductBasketStatusAsync();
            //return Json(productCampaingApiService,loadOptions);

            return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        }
    }
}
