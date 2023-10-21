
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IOrden : IGenericRepo<Orden>
{
    public Task<IEnumerable<object>> PrendasDeOrdenEnProduccion(int id);
    public  Task<IEnumerable<object>> Consulta4(string id);
}
