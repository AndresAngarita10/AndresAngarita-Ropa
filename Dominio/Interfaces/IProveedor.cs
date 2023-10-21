
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProveedor : IGenericRepo<Proveedor>
{
    public  Task<IEnumerable<Proveedor>> ProvPerNatural();
}
