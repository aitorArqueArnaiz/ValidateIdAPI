using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ValidateId.Infrastructure.Interfaces;

namespace ValidateId.Infrastructure.Data.Repositories
{
    public class InMemmoryRepository : DbContext, IRepository
    {
        #region Class variables

        public DbSet<dynamic> _shoppingBaskets { get; set; }

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
            return _shoppingBaskets.Local.ToList();
        }

        public bool AddShoppingBasket(dynamic shoppingBasket)
        {
            dynamic userBasket = new ExpandoObject();

            userBasket.CreationDate = shoppingBasket.Basket.CreationDate;
            userBasket.Units = shoppingBasket.Basket.Units;
            userBasket.Total = shoppingBasket.Basket.Totl;

            _shoppingBaskets.Add(userBasket);

            return true;
        }

        #endregion
    }
}