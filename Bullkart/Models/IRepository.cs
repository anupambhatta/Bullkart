using System.Linq;

namespace Bullkart.Models {

    public interface IRepository {

        ApplicationDbContext dbContext { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Catalog> Catalogs { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Status> Statuses { get; }
        IQueryable<Order> Orders { get; }
        IQueryable<OrderLine> OrderLines { get; }
        IQueryable<Address> Addresses { get; }

    }
}
