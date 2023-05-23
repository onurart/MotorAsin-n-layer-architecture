using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;
using MotorAsinBasketRobot.Entities.Dtos.IncomingOrderRequests;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientIncomingOrderRequestsController : Controller
    {
        private readonly IncomingOrderRequestsApiSevice _apiService;

        public ClientIncomingOrderRequestsController(IncomingOrderRequestsApiSevice apiService)
        {
            _apiService = apiService;
        }

        public async  Task<IActionResult> Index()
        {
            var productCampaingApiService = await _apiService.GetIncomingOrderRequestsAllAsync();
        
        return View(productCampaingApiService);
        } 
        //public async Task<object> GetBasketStatusList(DataSourceLoadOptions loadOptions, IncomingOrderRequestsPramertDto dto)
        //{
        //    var productCampaingApiService = await _apiService.GetIncomingOrderRequestsAllAsync();
        //    return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        //}
    }
}
