using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.Offer;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientProductCampaingController : Controller
    {
        private readonly ProductCampaingApiService _productCampaingApiService;

        public ClientProductCampaingController(ProductCampaingApiService productCampaingApiService)
        {
            _productCampaingApiService = productCampaingApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<object> ClientProductCampaingList(DataSourceLoadOptions loadOptions, ProductsCampaignsListPramertDto dto)
        {
            var productCampaingApiService = await _productCampaingApiService.GetProductCampaingAllAsync();
            return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        }
    }
}
