using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetalleVentaRepository : GenericRepo<DetalleVenta>, IDetalleVenta
{
    private readonly ApiContext _context;

    public DetalleVentaRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<DetalleVenta>> GetAllAsync()
    {
        return await _context.DetalleVentas
            .ToListAsync();
    }

    public override async Task<DetalleVenta> GetByIdAsync(int id)
    {
        return await _context.DetalleVentas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<DetalleVenta> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.DetalleVentas as IQueryable<DetalleVenta>;

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