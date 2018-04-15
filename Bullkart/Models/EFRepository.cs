using System.Collections.Generic;
using System.Linq;

namespace Bullkart.Models {

    public class EFRepository : IRepository {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        //Make the contex available so we can do updates
        public ApplicationDbContext dbContext => context;

        public IQueryable<Category> Categories => context.Categories;
        public IQueryable<Catalog> Catalogs => context.Catalogs;
        public IQueryable<Product> Products => context.Products;
        public IQueryable<Status> Statuses => context.Statuses;
        public IQueryable<Order> Orders => context.Orders;
        public IQueryable<OrderLine> OrderLines => context.OrderLines;
        public IQueryable<Address> Addresses => context.Addresses;
    }
}
