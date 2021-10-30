using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ValidateId.Infrastructure.Interfaces;
using NPOI.SS.Formula.Functions;

namespace ValidateId.Infrastructure.Data.Repositories
{
    public class InMemmoryRepository : DbContext, IInMemmoryRepository
    {
        public DbSet<T> ShoppingBaskets { get; set; }

        public InMemmoryRepository(DbContextOptions options) : base(options)
        {
            LoadShoppingBaskets();
        }

        public void LoadShoppingBaskets()
        {
        }

        public List<T> GetShoppingBaskets()
        {
            return null;
        }

        public T AddShoppingBasket()
        {
            return null;
        }
    }
}