

using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ColorRepository : GenericRepo<Color>, IColor
{
    private readonly ApiContext _context;

    public ColorRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Color>> GetAllAsync()
    {
        return await _context.Colores
            .ToListAsync();
    }

    public override async Task<Color> GetByIdAsync(int id)
    {
        return await _context.Colores
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Color> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Colores as IQueryable<Color>;

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