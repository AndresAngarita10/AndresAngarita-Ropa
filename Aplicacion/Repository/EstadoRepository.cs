using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class EstadoRepository : GenericRepo<Estado>, IEstado
{
    private readonly ApiContext _context;

    public EstadoRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados
            .ToListAsync();
    }

    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Estado> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Estados as IQueryable<Estado>;

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
}