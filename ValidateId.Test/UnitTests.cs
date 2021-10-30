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

        #endregion

        #region Class Start and tear down

        [SetUp]
        public void SetUp()
        {
            _shoppingBasket = new ShoppingBasket(new User(), new Basket());
        }

        [TearDown]
        public void TearDown()
        {
            _shoppingBasket = null;
        }

        #endregion

        #region Class tests

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to add a new item to a user basket.")]
        public void AddTestData(InMemmoryRepository context)
        {
            // Assert

            // Act

            // Arrange
        }

        #endregion
    }
}
