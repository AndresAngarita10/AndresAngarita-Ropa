using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    private RolRepository _Rol;
    private UsuarioRepository _usuarios;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    
    public IRol Roles
    {
        get{
            if(_Rol== null)
            {
                _Rol= new RolRepository(_context);
            }
            return _Rol;
        }
    }
    
    public IUsuario Usuarios
    {
        get{
            if(_usuarios== null)
            {
                _usuarios= new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public ICargo Cargos => throw new NotImplementedException();

    public ICliente Clientes => throw new NotImplementedException();

    public IColor Colores => throw new NotImplementedException();

    public IDepartamento Departamentos => throw new NotImplementedException();

    public IDetalleOrden DetalleOrdenes => throw new NotImplementedException();

    public IDetalleVenta DetalleVentas => throw new NotImplementedException();

    public IEmpleado Empleados => throw new NotImplementedException();

    public IEmpresa Empresas => throw new NotImplementedException();

    public IEstado Estados => throw new NotImplementedException();

    public IFormaPago FormaPagos => throw new NotImplementedException();

    public IGenero Generos => throw new NotImplementedException();

    public IInsumo Insumos => throw new NotImplementedException();

    public IInsumoPrenda InsumoPrendas => throw new NotImplementedException();

    public IInsumoProveedor InsumoProveedores => throw new NotImplementedException();

    public IInventario Inventarios => throw new NotImplementedException();

    public IInventarioTalla InventarioTallas => throw new NotImplementedException();

    public IMunicipio Municipios => throw new NotImplementedException();

    public IOrden Ordenes => throw new NotImplementedException();

    public IPais Paises => throw new NotImplementedException();

    public IPrenda Prendas => throw new NotImplementedException();

    public IProveedor Proveedores => throw new NotImplementedException();

    public ITalla Tallas => throw new NotImplementedException();

    public ITipoEstado TipoEstados => throw new NotImplementedException();

    public ITipoPersona TipoPersonas => throw new NotImplementedException();

    public ITipoProteccion TipoProtecciones => throw new NotImplementedException();

    public IVenta Ventas => throw new NotImplementedException();

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
