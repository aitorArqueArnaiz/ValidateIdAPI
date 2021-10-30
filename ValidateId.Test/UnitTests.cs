using NUnit.Framework;
using ValidateId.Infrastructure.Data.Repositories;

namespace ValidateId.Test
{
    [TestFixture]
    public class UnitTests
    {
        #region Class Variables
        #endregion

        #region Class Start and tear down

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
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
