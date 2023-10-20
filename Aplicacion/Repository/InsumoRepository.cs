using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Repository;

public class InsumoRepository : GenericRepo<Insumo>, IInsumo
{
    private readonly ApiContext _context;

    public InsumoRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Insumo>> GetAllAsync()
    {
        return await _context.Insumos
            .ToListAsync();
    }

    public override async Task<Insumo> GetByIdAsync(int id)
    {
        return await _context.Insumos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Insumo> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Insumos as IQueryable<Insumo>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
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