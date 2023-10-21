
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IInsumoPrenda: IGenericRepo<InsumoPrenda>
{
    public  Task<IEnumerable<object>> InsumosYCostoProduccion(string id);

}
