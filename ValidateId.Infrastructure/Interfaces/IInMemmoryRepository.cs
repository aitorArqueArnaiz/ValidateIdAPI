
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;

namespace ValidateId.Infrastructure.Interfaces
{
    public interface IInMemmoryRepository
    {

        /// <summary>Method that creates the first shopping basket.</summary>
        void LoadShoppingBaskets();

        /// <summary>Method that gets all the shopping baskets existing in the current in memmory data base.</summary>
        /// <returns>The list of all shopping baskets/products.</returns>
        List<T> GetShoppingBaskets();
    }
}
