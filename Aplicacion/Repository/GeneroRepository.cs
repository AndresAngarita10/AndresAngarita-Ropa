using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Repository;

public class GeneroRepository : GenericRepo<Genero>, IGenero
{
    private readonly ApiContext _context;

    public GeneroRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _context.Generos
            .ToListAsync();
    }

    public override async Task<Genero> GetByIdAsync(int id)
    {
        return await _context.Generos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Genero> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Generos as IQueryable<Genero>;

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