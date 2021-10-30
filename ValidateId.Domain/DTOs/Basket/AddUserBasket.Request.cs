using System.Collections.Generic;

namespace ValidateId.Domain.DTOs.Basket
{
    public class AddUserBasketRequest
    {
        public string CreationDate { get; set; }

        public Dictionary<int, string> Units { get; set; }

        public double Total { get; set; }
    }
}
