
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface ITipoProteccion : IGenericRepo<TipoProteccion>
{
    public  Task<IEnumerable<object>> PrendasPorTipoProteccion();
}
