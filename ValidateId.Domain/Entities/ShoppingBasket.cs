
namespace ValidateId.Domain.Entities
{
    public class ShoppingBasket
    {
        public User User;
        public Basket Basket;

        public ShoppingBasket(User user, Basket basket)
        {
            User = user;
            Basket = basket;
        }
    }
}
