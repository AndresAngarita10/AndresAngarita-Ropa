using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoProteccionRepository : GenericRepo<TipoProteccion>, ITipoProteccion
{
    private readonly ApiContext _context;

    public TipoProteccionRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<TipoProteccion>> GetAllAsync()
    {
        return await _context.TipoProtecciones
            .ToListAsync();
    }

    public override async Task<TipoProteccion> GetByIdAsync(int id)
    {
        return await _context.TipoProtecciones
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<TipoProteccion> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.TipoProtecciones as IQueryable<TipoProteccion>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    
    public async Task<IEnumerable<object>> PrendasPorTipoProteccion()
    {
        return await (
            from o in _context.TipoProtecciones
            select new
            {
                NombreProteccion = o.Descripcion,
                Prendas = (
                    from pre in _context.Prendas
                    where pre.IdTipoProteccion == o.Id
                    select new
                    {
                        Id = pre.Id,
                        Nombre = pre.Nombre 
                    }
                ).ToList()
            }
        ).ToListAsync();
    }
}