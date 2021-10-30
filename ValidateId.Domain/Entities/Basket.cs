
using System;
using System.Collections.Generic;
using ValidateId.Domain.Base;

namespace ValidateId.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string CreationDate { get; set; }
        public Dictionary<int, string> Units { get; set; }

        public Basket()
        {
            Units = new Dictionary<int, string>();
            CreationDate = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
}
