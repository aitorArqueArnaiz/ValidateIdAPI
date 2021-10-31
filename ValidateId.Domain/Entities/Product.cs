
using Newtonsoft.Json;
using System;
using ValidateId.Domain.Base;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Domain.Entities
{
    public class Product : BaseEntity
    {
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        public Product(int quantity, string name)
        {
            Quantity = quantity;
            Name = name;
        }
    }
}
