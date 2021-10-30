
using Newtonsoft.Json;

namespace ValidateId.Domain.Entities
{
    public class ShoppingBasket
    {
        [JsonProperty("User")]
        public User User { get; set; }

        [JsonProperty("Basket")]
        public Basket Basket { get; set; }

        public ShoppingBasket(User user, Basket basket)
        {
            User = user;
            Basket = basket;
        }
    }
}
