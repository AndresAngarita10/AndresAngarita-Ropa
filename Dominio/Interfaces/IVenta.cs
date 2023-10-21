
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IVenta : IGenericRepo<Venta>
{
    public Task<IEnumerable<object>> VentaPorEmpleadoEspecifico(string id);
}
