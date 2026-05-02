using Microsoft.AspNetCore.Mvc;
using Tarea3.DATA;
using Tarea3.MODEL;

namespace Tarea3.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;
        public EmpleadosController(IEmpleadoRepository repo) { _repo = repo; }

        public IActionResult Index(string busqueda = "", int pagina = 1)
        {
            int tamano = 5;
            var lista = _repo.ObtenerPaginado(pagina, tamano, busqueda);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)_repo.ContarTotal(busqueda) / tamano);
            ViewBag.TotalRegistros = _repo.ContarTotal(busqueda);
            ViewBag.Busqueda = busqueda;

            return View(lista);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Activo = true;
                _repo.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        public IActionResult Edit(int id) => View(_repo.ObtenerPorId(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            var emp = _repo.ObtenerPorId(id);
            if (emp != null)
            {
                emp.Activo = !emp.Activo;
                _repo.Actualizar(emp);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}