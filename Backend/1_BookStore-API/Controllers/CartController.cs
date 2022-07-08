using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Book_e_Sale.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(string? keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c));
            return Ok(cartModels);
        }

        [HttpGet]
        [Route("list2")]
        [ProducesResponseType(typeof(ListResponse<CartModelResponse>), (int)HttpStatusCode.OK)]
        public IActionResult GetCartItem2(int UserId)
        {


            var cartitem = _cartRepository.GetCartListall(UserId);
            ListResponse<CartModelResponse> listResponce = new ListResponse<CartModelResponse>()
            {
                Results = cartitem.Results.Select(c => new CartModelResponse(c)),
                TotalRecords = cartitem.TotalRecords,
            };

            return Ok(listResponce);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.BookId,
                UserId = model.UserId
            };
            cart = _cartRepository.AddCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.BookId,
                UserId = model.UserId
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest();

            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
