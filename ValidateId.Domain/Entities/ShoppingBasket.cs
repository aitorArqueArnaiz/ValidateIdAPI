using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ValidateId.Domain.Base;

namespace ValidateId.Domain.Entities
{
    public class ShoppingBasket : BaseEntity
    {
        [JsonIgnore]
        public string CreationDate { get; set; }

        [JsonProperty("Products")]
        public List<Product> Products { get; set; }

        [JsonProperty("Products")]
        public User User { get; set; }

        public ShoppingBasket(int userId)
        {
            Products = new List<Product>() { };
            CreationDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            User = new User();
            User.Id = userId;
        }
    }
}
