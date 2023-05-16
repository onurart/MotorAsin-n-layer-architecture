using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Components.AdminDataGrids
{
    public class AdminRepots : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
