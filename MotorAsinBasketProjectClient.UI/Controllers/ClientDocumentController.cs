using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientDocumentController : Controller
    {
        private readonly ClientDocumentApiService _clientDocumentApiService;

        public ClientDocumentController(ClientDocumentApiService clientDocumentApiService)
        {
            _clientDocumentApiService = clientDocumentApiService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<object> ClientDocumentList(DataSourceLoadOptions loadOptions, DocumentListPramertDto dto)
        {
            var productCampaingApiService = await _clientDocumentApiService.GetClientDocumentllAsync();
            return DataSourceLoader.Load(productCampaingApiService, loadOptions);
        }
    }
}
