using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ValidateId.Infrastructure.Interfaces;

namespace ValidateId.Infrastructure.Data.Repositories
{
    public class InMemmoryRepository : DbContext, IInMemmoryRepository
    {
        #region Class variables

        public DbSet<dynamic> ShoppingBaskets { get; set; }

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

        public List<dynamic> GetShoppingBaskets()
        {
            return null;
        }

        public bool AddShoppingBasket()
        {
            return true;
        }

        #endregion
    }
}