using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Components.Clients
{
    public class ClientSalesTileContainer : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
