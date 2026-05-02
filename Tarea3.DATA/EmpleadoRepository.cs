using Tarea3.MODEL;
using Microsoft.EntityFrameworkCore;

namespace Tarea3.DATA
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;
        public EmpleadoRepository(AppDbContext context) { _context = context; }

        public IEnumerable<Empleado> ObtenerTodos() => _context.Empleados.ToList();

        public Empleado? ObtenerPorId(int id) => _context.Empleados.Find(id);

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string t)
        {
            return _context.Empleados
                .Where(e => e.Nombre.Contains(t) || e.Apellidos.Contains(t) || e.Departamento.Contains(t))
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda)
        {
            IQueryable<Empleado> query = _context.Empleados;
            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e => e.Nombre.Contains(busqueda) ||
                                       e.Apellidos.Contains(busqueda) ||
                                       e.Departamento.Contains(busqueda));
            }
            return query.Skip((pagina - 1) * tamano).Take(tamano).ToList();
        }

        public int ContarTotal(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda)) return _context.Empleados.Count();
            return _context.Empleados.Count(e => e.Nombre.Contains(busqueda) ||
                                               e.Apellidos.Contains(busqueda) ||
                                               e.Departamento.Contains(busqueda));
        }

        public void Agregar(Empleado e) { _context.Empleados.Add(e); _context.SaveChanges(); }
        public void Actualizar(Empleado e) { _context.Empleados.Update(e); _context.SaveChanges(); }
        public void Eliminar(int id) { /*No se debe de eliminar fisicamente, por lo tanto queda este espacio vacio (pero listo por si en algun momento se quiere implementar esta funcion) */ }
    }
}