using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Repository;

public class FormaPagoRepository : GenericRepo<FormaPago>, IFormaPago
{
    private readonly ApiContext _context;

    public FormaPagoRepository (ApiContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<FormaPago>> GetAllAsync()
    {
        return await _context.FormaPagos
            .ToListAsync();
    }

    public override async Task<FormaPago> GetByIdAsync(int id)
    {
        return await _context.FormaPagos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<FormaPago> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.FormaPagos as IQueryable<FormaPago>;

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