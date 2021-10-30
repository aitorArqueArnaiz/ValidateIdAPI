using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ValidateId.Infrastructure.Interfaces;
using NPOI.SS.Formula.Functions;

namespace ValidateId.Infrastructure.Data.Repositories
{
    public class InMemmoryRepository : DbContext, IInMemmoryRepository
    {
        #region Class variables

        public DbSet<T> ShoppingBaskets { get; set; }

        #endregion

        #region Class constructor

        public InMemmoryRepository(DbContextOptions options) : base(options)
        {
            LoadShoppingBaskets();
        }

        #endregion

        #region Class methods

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

        #endregion
    }
}