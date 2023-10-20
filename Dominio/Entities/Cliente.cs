
using Microsoft.EntityFrameworkCore;

namespace Dominio.Entities;

public class Cliente : BaseEntity
{
    public string IdentificacionCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersona { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdMunicipio { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<Orden> Ordenes { get; set; }
}
