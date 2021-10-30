

using System.Collections.Generic;
using ValidateId.Domain.Entities;

namespace ValidateId.Bussines.Interfaces.Basket
{
    public interface IBasket
    {
        ShoppingBasket AddShoppingBasketToUser(ShoppingBasket shoppingBasket);

        List<ShoppingBasket> GetAllShoppingBaskets();

    }
}
