﻿using System.Collections.Generic;
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

        public bool AddShoppingBasket(dynamic shoppingBasket, double totalProductCost = 0.0)
        {
            dynamic userBasket = new ExpandoObject();

            userBasket.User = shoppingBasket.User;
            userBasket.Basket = shoppingBasket.Basket;
            userBasket.Total = totalProductCost;

            _shoppingBaskets.Add(userBasket);

            return true;
        }

        #endregion
    }
}