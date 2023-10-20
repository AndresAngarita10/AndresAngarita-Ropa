using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository;

public class PrendaRepository : GenericRepo<Prenda>, IPrenda
{
    private readonly ApiContext _context;

    public PrendaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Prenda>> GetAllAsync()
    {
        return await _context.Prendas
            .ToListAsync();
    }

    public override async Task<Prenda> GetByIdAsync(int id)
    {
        return await _context.Prendas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Prenda> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Prendas as IQueryable<Prenda>;

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