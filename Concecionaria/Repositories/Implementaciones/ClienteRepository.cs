using Concecionaria.Data;
using Concecionaria.Entity;
using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.Repositories.Implementaciones
{
    public class ClienteRepostory : GenericRepository<Cliente>, IClientesRepository
    {
        public ClienteRepostory(ApplicationDbContext db) : base(db)
        {

        }
    }
}
