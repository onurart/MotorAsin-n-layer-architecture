using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;
using MotorAsinBasketRobot.Entities.Dtos.Product;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientProductController : Controller
    {
        private readonly ClientProductApiService _clientProductApiService;

        public ClientProductController(ClientProductApiService clientProductApiService)
        {
            _clientProductApiService = clientProductApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<object> GetClientProductList(DataSourceLoadOptions loadOptions, ProductListPramertDto dto)
        {
            var productCampaingApiService = await _clientProductApiService.GetProductAllAsync();
            return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        }
    }
}
