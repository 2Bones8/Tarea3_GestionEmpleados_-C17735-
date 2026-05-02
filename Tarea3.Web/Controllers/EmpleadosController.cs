using Microsoft.AspNetCore.Mvc;

namespace Tarea3.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
