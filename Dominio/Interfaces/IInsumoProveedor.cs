
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IInsumoProveedor: IGenericRepo<InsumoProveedor>
{
    public  Task<IEnumerable<object>> InsumosPorProveedor(string nit);
}
