//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RewardExchangeSystem.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Contact { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Quantity { get; set; }
        public Nullable<int> TotalPoints { get; set; }
        public Nullable<int> RemaningPoint { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
