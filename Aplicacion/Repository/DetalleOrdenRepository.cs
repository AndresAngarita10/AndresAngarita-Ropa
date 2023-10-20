using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetalleOrdenRepository : GenericRepo<DetalleOrden>, IDetalleOrden
{
    private readonly ApiContext _context;

    public DetalleOrdenRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<DetalleOrden>> GetAllAsync()
    {
        return await _context.DetalleOrdenes
            .ToListAsync();
    }

    public override async Task<DetalleOrden> GetByIdAsync(int id)
    {
        return await _context.DetalleOrdenes
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<DetalleOrden> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.DetalleOrdenes as IQueryable<DetalleOrden>;

        if (!string.IsNullOrEmpty(search.ToString()))
        {
            query = query.Where(p => p.Id == search);
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