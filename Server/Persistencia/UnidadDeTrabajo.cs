using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia
{
    public class UnidadDeTrabajo : IDisposable
    {
        public readonly BaseDatosContext _context;

        // Distribuidora
        public IRubroRepository rubroRepository;
        public IEmpresaDistribuidoraRepository distribuidoraRepository;
        public INITRepository nitRepository;
        public IEmpresaClienteRepository empresaClienteRepository;
        public IProveedorRepository empresaProveedorRepository;
        public ITarjetaClienteRepository tarjetaClienteRepository;
        public ISucursalRepository sucursalesRepository;
        public IVehiculoRepository vechiculoRepository;
        public IAsignacionVechiculoConductorRepository asignacionVechiculoConductorRepository;
        public IClienteDistribuidoraRepository clienteDistribuidoraRepository;

        // Inventario
        public IProductoRepository productoRepository;
        public ITipoProductoRepository tipoProductoRepository;
        public IStockRepository stockRepository;
        public INotaRecepcionRepository notaRecepcionRepository;
        public IDetalleNotaRecepcionRepository detalleNotaRecepcionRepository;

        // Pedidos
        public IOrdenPedidoRepository ordenRepository;
        public IDetalleOrdenPedidoRepository detalleOrdenPedidoRepository;
        public IFacturaRepository facturaRepository;
        public IOrdenPedidoRepository ordenPedidoRepository;
        public IPedidoRepository pedidoRepository;

        // Personal
        public IUsuarioRepository usuarioRepository;
        public IResponsableEmpresaRepository responsableDistribuidoraRepository;
        public IRolRepository rolRepository;
        public IResponsableAlmacenRepository responsableAlmacenRepository;
        public IConductorRepository conductorRepository;
        public IUsuariosRolesRepository usuariosRolesRepository;

        public UnidadDeTrabajo(BaseDatosContext context)
        {
            _context = context;
            // Distribuidora
            rubroRepository = new RubroRepository(_context);
            distribuidoraRepository = new EmpresaDistribuidoraRepository(_context);
            nitRepository = new NITRepository(_context);
            empresaClienteRepository = new EmpresaClienteRepository(_context);
            empresaProveedorRepository = new ProveedorRepository(_context);
            tarjetaClienteRepository = new TarjetaClienteRepository(_context);
            sucursalesRepository = new SucursalRepository(_context);
            vechiculoRepository = new VehiculoRepository(_context);
            asignacionVechiculoConductorRepository = new AsignacionVechiculoConductorRepository(_context);
            clienteDistribuidoraRepository = new ClienteDistribuidoraRepository(_context);

            // Inventario
            productoRepository = new ProductoRepository(_context);
            tipoProductoRepository = new TipoProductoRepository(_context);
            stockRepository = new StockRepository(_context);
            notaRecepcionRepository = new NotaRecepcionRepository(_context);
            detalleNotaRecepcionRepository = new DetalleNotaRecepcionRepository(_context);

            // Pedidos
            ordenRepository = new OrdenPedidoRepository(_context);
            detalleOrdenPedidoRepository = new DetalleOrdenPedidoRepository(_context);
            facturaRepository = new FacturaRepository(_context);
            ordenPedidoRepository = new OrdenPedidoRepository(_context);
            pedidoRepository = new PedidoRepository(_context);

            // Personal
            usuarioRepository = new UsuarioRepository(_context);
            responsableDistribuidoraRepository = new ResponsableEmpresaRepository(_context);
            rolRepository = new RolRepository(_context);
            responsableAlmacenRepository = new ResponsableAlmacenRepository(_context);
            conductorRepository = new ConductorRepository(_context);
            usuariosRolesRepository = new UsuariosRolesRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
