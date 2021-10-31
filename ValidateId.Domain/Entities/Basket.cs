
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ValidateId.Domain.Base;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Domain.Entities
{
    public class Basket : BaseEntity
    {
        /*
         * Example of employee DTO
             * {
                 "Units": "{""2"":""The Hobbit"",""5"":""Breaking Bad""}"
              }
         */

        [JsonIgnore]
        public string CreationDate { get; set; }

        [JsonProperty("Units")]
        public Dictionary<int, string> Units { get; set; }


        public Basket()
        {
            Units = new Dictionary<int, string>();
            CreationDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
