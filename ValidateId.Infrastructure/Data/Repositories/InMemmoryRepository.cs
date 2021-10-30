﻿using System.Collections.Generic;
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
            return null;
        }

        public bool AddShoppingBasket(dynamic shoppingBasket)
        {
            return true;
        }

        #endregion
    }
}