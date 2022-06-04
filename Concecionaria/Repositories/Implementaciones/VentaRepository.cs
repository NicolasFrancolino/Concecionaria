using Concecionaria.Data;
using Concecionaria.Entity;
using Concecionaria.Repositories.Interfaces;

namespace Concecionaria.Repositories.Implementaciones
{
    public class VentaRepository : GenericRepository<Venta>, IVentasRepository
    {
        public VentaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
