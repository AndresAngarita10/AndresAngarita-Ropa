using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class VentaRepository : GenericRepo<Venta>, IVenta
{
    private readonly ApiContext _context;

    public VentaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
            .ToListAsync();
    }

    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Venta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ventas as IQueryable<Venta>;

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
    
    public async Task<IEnumerable<object>> VentaPorEmpleadoEspecifico(string id)
    {
        return await (
            from p in _context.Ventas
            join emp in _context.Empleados on p.IdEmpleado equals emp.Id
            where emp.IdentificacionEmpleado.Equals(id)
            select new
            {
                IdEmpleado = emp.Id,
                Empleado = emp.Nombre,
                Fecha = p.Fecha,
                Total = (
                    from fact in _context.DetalleVentas
                    where fact.IdVenta == p.Id
                    select new
                    {
                        Total = fact.Cantidad*fact.ValorUnitario,
                    }
                ).Sum(x => x.Total)
            }
        ).ToListAsync();
    }

    /* 
    return await (
            from p in _context.Partners
            join pt in _context.PartnerTypes on p.PartnerTypeIdFk equals pt.Id
            join es in _context.Specialities on p.SpecialtyIdFk equals es.Id
            where pt.Name.Contains("Cliente")
            where es.Name.Contains("Cliente")
            select new
            {
                Name = p.Name,
                Pets = (
                    from pet in _context.Pets
                    join esp in _context.Species on pet.SpeciesIdFk equals esp.Id
                    where pet.UserOwnerId == p.Id
                    select new
                    {
                        Name = pet.Name,
                        Birth = pet.DateBirth,
                        Especies = esp.Name
                    }
                ).ToList()
            }
        ).ToListAsync();
     */
}