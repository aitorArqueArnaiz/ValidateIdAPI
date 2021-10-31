using System.Collections.Generic;
using ValidateId.Domain.Entities;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Domain.DTOs.Basket
{
    public class AddUserBasketRequest
    {
        public string CreationDate { get; set; }

        public User User { get; set; }

        public Dictionary<int, string> Units { get; set; }
    }
}
