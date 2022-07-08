using BookStore.Models.ViewModels;

namespace BookStore.Models.Models
{
    public class CartModel
    {
        public CartModel() { }

        public CartModel(Cart cart)
        {
            Id = cart.Id;
            UserId = cart.UserId;
            BookId = cart.Bookid;
            Quantity = cart.Quantity;
            //BookName = cart.Book.Name;
           // Price = cart.Book.Price;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        //public string BookName { get; set; }
        public int Quantity { get; set; }
        //public decimal Price { get; set; }

    }
}
