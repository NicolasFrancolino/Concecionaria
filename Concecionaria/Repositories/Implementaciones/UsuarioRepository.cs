using Concecionaria.Data;
using Concecionaria.Entity;
using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.Repositories.Implementaciones
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
        }

    

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            return _context.Usuarios.Any(a => a.Email == email);
        }
    }
}
