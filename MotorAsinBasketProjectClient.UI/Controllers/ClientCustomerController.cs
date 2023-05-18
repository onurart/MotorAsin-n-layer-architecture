using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.Customer;
using MotorAsinBasketRobot.Entities.Dtos.Documents;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientCustomerController : Controller
    {
        private readonly ClientCustomersApiService _clientDocumentApiService;

        public ClientCustomerController(ClientCustomersApiService clientDocumentApiService)
        {
            _clientDocumentApiService = clientDocumentApiService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<object> ClientDocumentList(DataSourceLoadOptions loadOptions, CustomerListPramertDto dto)
        {
            var productCampaingApiService = await _clientDocumentApiService.GetClientustomerllAsync();
            return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        }
    }
}
