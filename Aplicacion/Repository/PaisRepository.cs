using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepo<Pais>, IPais
{
    private readonly ApiContext _context;

    public PaisRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises
            .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Paises
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Paises as IQueryable<Pais>;

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