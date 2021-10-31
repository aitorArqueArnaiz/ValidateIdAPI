using System.Collections.Generic;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using ValidateId.Infrastructure.Interfaces;

namespace ValidateId.Infrastructure.Data.Repositories
{
    public class InMemmoryRepository : DbContext, IRepository
    {
        #region Class variables

        public List<dynamic> _shoppingBaskets { get; set; }

        #endregion

        #region Class constructor

        public InMemmoryRepository(DbContextOptions options) : base(options)
        {
            LoadShoppingBaskets();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        #endregion

        #region Class methods

        public void LoadShoppingBaskets()
        {
            _shoppingBaskets = new List<dynamic>() { };
        }

        public List<dynamic> GetShoppingBaskets()
        {
            return _shoppingBaskets;
        }

        public bool AddShoppingBasket(dynamic shoppingBasket)
        {
            dynamic userBasket = new ExpandoObject();

            userBasket.CreationDate = shoppingBasket.Basket.CreationDate;
            userBasket.Units = shoppingBasket.Basket.Units;
            userBasket.Total = shoppingBasket.Basket.Total;

            _shoppingBaskets.Add(userBasket);

            return true;
        }

        #endregion
    }
}