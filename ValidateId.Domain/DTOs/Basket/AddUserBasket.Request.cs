using System.Collections.Generic;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Domain.DTOs.Basket
{
    public class AddUserBasketRequest
    {
        public string CreationDate { get; set; }

        public Dictionary<int, ProductId> Units { get; set; }

        public double Total { get; set; }
    }
}
