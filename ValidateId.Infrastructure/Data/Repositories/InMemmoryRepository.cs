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

        public Dictionary<int, dynamic> _shoppingBaskets { get; set; }

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
            _shoppingBaskets = new Dictionary<int, dynamic>() { };
        }

        public List<dynamic> GetShoppingBaskets()
        {
            return _shoppingBaskets.Select(kvp => kvp.Value).ToList();
        }

        public bool AddShoppingBasket(dynamic shoppingBasket, double totalProductCost = 0.0)
        {
            dynamic userBasket = new ExpandoObject();
            userBasket.User = shoppingBasket.User;
            userBasket.Basket = shoppingBasket.Basket;
            userBasket.Total = totalProductCost;

            _shoppingBaskets.Add(shoppingBasket.User.Id, userBasket);

            return true;
        }

        #endregion
    }
}