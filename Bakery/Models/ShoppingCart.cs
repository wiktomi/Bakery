//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bakery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        [DisplayName("Nazwa produktu")]
        public string ProductName { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Data")]
        public System.DateTime StartDate { get; set; }
    }
}
