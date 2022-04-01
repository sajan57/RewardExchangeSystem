using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RewardExchangeSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [ReadOnly(true)]
        public int ProductPoints { get; set; }
    }
}