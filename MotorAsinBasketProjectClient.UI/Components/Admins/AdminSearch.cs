using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Components.Admins
{
    public class AdminSearch : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
