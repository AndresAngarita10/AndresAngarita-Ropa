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
}