using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Data.Repositories;

namespace ValidateId.Test
{
    [TestFixture]
    public class UnitTests
    {
        #region Class Variables

        private ShoppingBasket _shoppingBasket;
        InMemmoryRepository _context;

        #endregion

        #region Class Start and tear down

        [SetUp]
        public void SetUp()
        {
            _shoppingBasket = new ShoppingBasket(new User(), new Basket());
            _context = new InMemmoryRepository(null);

        }

        [TearDown]
        public void TearDown()
        {
            _shoppingBasket = null;
            _context = null;
        }

        #endregion

        #region Class tests

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to add a new item to a user basket.")]
        public void AddShoppingBasket_ToUser_Test()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        #endregion
    }
}
