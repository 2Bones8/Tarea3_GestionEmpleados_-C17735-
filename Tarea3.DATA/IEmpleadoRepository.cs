using Tarea3.MODEL;

namespace Tarea3.DATA
{
    internal interface IEmpleadoRepository
    {
        IEnumerable<Empleado> ObtenerTodos();
        Empleado? ObtenerPorId(int id);
        IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino);
        IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda);
        int ContarTotal(string busqueda);
        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
        void Eliminar(int id);

    }
}
