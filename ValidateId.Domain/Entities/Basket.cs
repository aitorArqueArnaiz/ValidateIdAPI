
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ValidateId.Domain.Base;

namespace ValidateId.Domain.Entities
{
    public class Basket : BaseEntity
    {
        /*
         * Example of employee DTO
             * {
                "CreationDate": "2000/01/01",
                 "Total": 56.99,
                 "Units": "{""2"":""The Hobbit"",""5"":""Breaking Bad""}"
              }
         */

        [JsonProperty("CreationDate")]
        public string CreationDate { get; set; }

        [JsonProperty("Units")]
        public Dictionary<int, string> Units { get; set; }

        public double Total { get; set; }

        public Basket()
        {
            Units = new Dictionary<int, string>();
            CreationDate = DateTime.Now.ToString("yyyy/MM/dd");
            Total = double.MinValue;
        }
    }
}
