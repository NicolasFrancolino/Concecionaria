using Concecionaria.Data;
using Concecionaria.Repositories.Implementaciones;
using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IClientesRepository ClienteRepo { get; private set; }

        public IVentasRepository VentaRepo { get; private set; }

        public IVehiculoRepository VehiculoRepo { get; private set; }
        public IUsuarioRepository UsuarioRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ClienteRepo = new ClienteRepostory(context);
            VentaRepo = new VentaRepository(context);
            VehiculoRepo = new VehiculoRepository(context);
            UsuarioRepo = new UsuarioRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

