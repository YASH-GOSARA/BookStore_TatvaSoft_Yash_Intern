using System;
using System.Collections.Generic;

namespace BookStore.Models.ViewModels
{
    public partial class Cart
    {
        public Cart()
        {
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Bookid { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
