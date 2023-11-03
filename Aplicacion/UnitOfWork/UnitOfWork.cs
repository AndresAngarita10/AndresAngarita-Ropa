using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly ApiContext _context;


    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    private RolRepository _Rol;
    private CargoRepository _Cargos;
    private UsuarioRepository _usuarios;
    private ClienteRepository _Clientes;
    private ColorRepository _Colores;
    private DepartamentoRepository _Departamentos;
    private DetalleOrdenRepository _DetalleOrdenes;
    private DetalleVentaRepository _DetalleVentas;
    private EmpleadoRepository _Empleados;
    private EmpresaRepository _Empresas;
    private EstadoRepository _Estados;
    private FormaPagoRepository _FormaPagos;
    private GeneroRepository _Generos;
    private InsumoRepository _Insumos;
    private InsumoPrendaRepository _InsumoPrendas;
    private InsumoProveedorRepository _InsumoProveedores;
    private InventarioRepository _Inventarios;
    private InventarioTallaRepository _InventarioTallas;
    private MunicipioRepository _Municipios;
    private OrdenRepository _Ordenes;
    private PaisRepository _Paises;
    private PrendaRepository _Prendas;
    private ProveedorRepository _Proveedores;
    private TallaRepository _Tallas;
    private TipoEstadoRepository _TipoEstados;
    private TipoPersonaRepository _TipoPersonas;
    private TipoProteccionRepository _TipoProtecciones;
    private VentaRepository _Ventas;


    public IRol Roles
    {
        get
        {
            if (_Rol == null)
            {
                _Rol = new RolRepository(_context);
            }
            return _Rol;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public ICargo Cargos
    {
        get
        {
            if (_Cargos == null)
            {
                _Cargos = new CargoRepository(_context);
            }
            return _Cargos;
        }
    }

    public ICliente Clientes
    {
        get
        {
            if (_Clientes == null)
            {
                _Clientes = new ClienteRepository(_context);
            }
            return _Clientes;
        }
    }

    public IColor Colores
    {
        get
        {
            if (_Colores == null)
            {
                _Colores = new ColorRepository(_context);
            }
            return _Colores;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_Departamentos == null)
            {
                _Departamentos = new DepartamentoRepository(_context);
            }
            return _Departamentos;
        }
    }

    public IDetalleOrden DetalleOrdenes
    {
        get
        {
            if (_DetalleOrdenes == null)
            {
                _DetalleOrdenes = new DetalleOrdenRepository(_context);
            }
            return _DetalleOrdenes;
        }
    }

    public IDetalleVenta DetalleVentas
    {
        get
        {
            if (_DetalleVentas == null)
            {
                _DetalleVentas = new DetalleVentaRepository(_context);
            }
            return _DetalleVentas;
        }
    }

    public IEmpleado Empleados
    {
        get
        {
            if (_Empleados == null)
            {
                _Empleados = new EmpleadoRepository(_context);
            }
            return _Empleados;
        }
    }
    public IEmpresa Empresas
    {
        get
        {
            if (_Empresas == null)
            {
                _Empresas = new EmpresaRepository(_context);
            }
            return _Empresas;
        }
    }

    public IEstado Estados
    {
        get
        {
            if (_Estados == null)
            {
                _Estados = new EstadoRepository(_context);
            }
            return _Estados;
        }
    }

    public IFormaPago FormaPagos
    {
        get
        {
            if (_FormaPagos == null)
            {
                _FormaPagos = new FormaPagoRepository(_context);
            }
            return _FormaPagos;
        }
    }

    public IGenero Generos
    {
        get
        {
            if (_Generos == null)
            {
                _Generos = new GeneroRepository(_context);
            }
            return _Generos;
        }
    }

    public IInsumo Insumos
    {
        get
        {
            if (_Insumos == null)
            {
                _Insumos = new InsumoRepository(_context);
            }
            return _Insumos;
        }
    }

    public IInsumoPrenda InsumoPrendas
    {
        get
        {
            if (_InsumoPrendas == null)
            {
                _InsumoPrendas = new InsumoPrendaRepository(_context);
            }
            return _InsumoPrendas;
        }
    }

    public IInsumoProveedor InsumoProveedores
    {
        get
        {
            if (_InsumoProveedores == null)
            {
                _InsumoProveedores = new InsumoProveedorRepository(_context);
            }
            return _InsumoProveedores;
        }
    }

    public IInventario Inventarios
    {
        get
        {
            if (_Inventarios == null)
            {
                _Inventarios = new InventarioRepository(_context);
            }
            return _Inventarios;
        }
    }

    public IInventarioTalla InventarioTallas
    {
        get
        {
            if (_InventarioTallas == null)
            {
                _InventarioTallas = new InventarioTallaRepository(_context);
            }
            return _InventarioTallas;
        }
    }

    public IMunicipio Municipios
    {
        get
        {
            if (_Municipios == null)
            {
                _Municipios = new MunicipioRepository(_context);
            }
            return _Municipios;
        }
    }

    public IOrden Ordenes
    {
        get
        {
            if (_Ordenes == null)
            {
                _Ordenes = new OrdenRepository(_context);
            }
            return _Ordenes;
        }
    }

    public IPais Paises
    {
        get
        {
            if (_Paises == null)
            {
                _Paises = new PaisRepository(_context);
            }
            return _Paises;
        }
    }

    public IPrenda Prendas
    {
        get
        {
            if (_Prendas == null)
            {
                _Prendas = new PrendaRepository(_context);
            }
            return _Prendas;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            if (_Proveedores == null)
            {
                _Proveedores = new ProveedorRepository(_context);
            }
            return _Proveedores;
        }
    }

    public ITalla Tallas
    {
        get
        {
            if (_Tallas == null)
            {
                _Tallas = new TallaRepository(_context);
            }
            return _Tallas;
        }
    }

    public ITipoEstado TipoEstados
    {
        get
        {
            if (_TipoEstados == null)
            {
                _TipoEstados = new TipoEstadoRepository(_context);
            }
            return _TipoEstados;
        }
    }

    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_TipoPersonas == null)
            {
                _TipoPersonas = new TipoPersonaRepository(_context);
            }
            return _TipoPersonas;
        }
    }
    public ITipoProteccion TipoProtecciones
    {
        get
        {
            if (_TipoProtecciones == null)
            {
                _TipoProtecciones = new TipoProteccionRepository(_context);
            }
            return _TipoProtecciones;
        }
    }

    public IVenta Ventas
    {
        get
        {
            if (_Ventas == null)
            {
                _Ventas = new VentaRepository(_context);
            }
            return _Ventas;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
