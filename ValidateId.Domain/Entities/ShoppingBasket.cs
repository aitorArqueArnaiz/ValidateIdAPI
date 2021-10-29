
namespace ValidateId.Domain.Entities
{
    public class ShoppingBasket
    {
        public User _user;
        public Basket _basket;

        public ShoppingBasket(User user, Basket basket)
        {
            _user = user;
            _basket = basket;
        }
    }
}
