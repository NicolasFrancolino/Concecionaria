using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientesRepository ClienteRepo { get; }
        IVentasRepository VentaRepo { get; }
        IVehiculoRepository VehiculoRepo { get; }
        IUsuarioRepository UsuarioRepo { get; }
        void Save();
    }
}
