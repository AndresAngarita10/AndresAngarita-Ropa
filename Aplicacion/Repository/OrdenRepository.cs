using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class OrdenRepository : GenericRepo<Orden>, IOrden
{
    private readonly ApiContext _context;

    public OrdenRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Orden>> GetAllAsync()
    {
        return await _context.Ordenes
            .ToListAsync();
    }

    public override async Task<Orden> GetByIdAsync(int id)
    {
        return await _context.Ordenes
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Orden> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ordenes as IQueryable<Orden>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<object>> PrendasDeOrdenEnProduccion(int idOrden)
    {
        return await (
            from o in _context.Ordenes
            join dor in _context.DetalleOrdenes on o.Id equals dor.IdOrden
            join est in _context.Estados on dor.IdEstado equals est.Id
            where o.Id == idOrden
            where est.Descripcion == "Produccion"
            select new
            {
                FechaOrden = o.Fecha,
                Etado = est.Descripcion,
                Prendas = (
                    from pre in _context.Prendas
                    where pre.Id == dor.IdPrenda
                    select new
                    {
                        Nombre = pre.Nombre 
                    }
                ).ToList()
            }
        ).ToListAsync();
    }

    
    public async Task<IEnumerable<object>> Consulta4(string id)
    {
        return await (
            from o in _context.Ordenes
            join cli in _context.Clientes on o.IdCliente equals cli.Id
            where cli.IdentificacionCliente.Equals(id)
            select new
            {
                IdCliente = cli.IdentificacionCliente,
                Cliente = cli.Nombre,
                Municipio = cli.Municipio.Nombre,
                Orden = (
                    from est in _context.Estados
                    where est.Id == o.IdEstado
                    select new
                    {
                        IdOrden = o.Id,
                        IdEstado = est.Id,
                        Estado = est.Descripcion,
                        Fecha =  o.Fecha 
                    }
                ).ToList(),
                DetalleOrden = (
                    from deto in _context.DetalleOrdenes
                    join pre in _context.Prendas on deto.IdPrenda equals pre.Id
                    where deto.IdOrden == o.Id
                    select new {
                        Codigo = pre.IdentificacionPrenda,
                        Prenda = pre.Nombre,
                        TotalCop = deto.CantidadProducida*pre.ValorUnitatioCop,
                        TotalUsd= deto.CantidadProducida*pre.ValorUnitarioUsd
                    }
                ).ToList(),
                ValorTotalOrdenEnPesos = (
                    from deto in _context.DetalleOrdenes
                    join pre in _context.Prendas on deto.IdPrenda equals pre.Id
                    where deto.IdOrden == o.Id
                    select new {
                        Total = deto.CantidadProducida*pre.ValorUnitatioCop
                    }
                ).Sum(x => x.Total),
                ValorTotalOrdenEnUSD = (
                    from deto in _context.DetalleOrdenes
                    join pre in _context.Prendas on deto.IdPrenda equals pre.Id
                    where deto.IdOrden == o.Id
                    select new {
                        Total = deto.CantidadProducida*pre.ValorUnitarioUsd
                    }
                ).Sum(x => x.Total)
            }
        ).ToListAsync();
    }
}