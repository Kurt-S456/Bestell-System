using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    public class StaffOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
