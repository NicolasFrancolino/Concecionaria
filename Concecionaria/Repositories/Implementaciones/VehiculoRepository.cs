using Concecionaria.Data;
using Concecionaria.Entity;
using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.Repositories.Implementaciones
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
