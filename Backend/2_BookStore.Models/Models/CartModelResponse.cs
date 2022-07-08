using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class CartModelResponse
    {
        public CartModelResponse() { }
        public CartModelResponse(Cart cart)
        {

            this.Id = cart.Id;
            this.UserId = cart.UserId;
            this.BookId = cart.Bookid;
            this.Quantity = cart.Quantity;
            this.Price = cart.Book.Price;
            this.Base64image = cart.Book.Base64image;
            this.Name = cart.Book.Name;



        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Base64image { get; set; }
    }
}
