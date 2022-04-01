using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RewardExchangeSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10,ErrorMessage ="Mobile number should be 10 digits!")]
        public string Contact { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "Required")]
        [ReadOnly(true)]
        public string Quantity { get; set; }
        [ReadOnly(true)]
        public string TotalPoints { get; set; }
        [ReadOnly(true)]
        public string RemaningPoint { get; set; }

    }
}