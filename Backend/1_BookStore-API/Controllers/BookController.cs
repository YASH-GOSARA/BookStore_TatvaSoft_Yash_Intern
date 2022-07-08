using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Book_e_Sale.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        BookRepository _bookRepository = new BookRepository();
        [HttpGet]
        [Route("list")]
        public IActionResult GetBooks(int pageIndex = 1, int pageSize = 10, string? keyword = "")
        {
            var books = _bookRepository.GetBooks(pageIndex,pageSize,keyword);

            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                Results = books.Results.Select(c => new BookModel(c)),
                TotalRecords = books.TotalRecords,
            };
            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(BookModel), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BookModel), (int)System.Net.HttpStatusCode.NotFound)]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if(book == null)
                return NotFound();

            return Ok(new BookModel(book));
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(BookModel), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult AddBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");

            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);
            return Ok(bookModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(BookModel), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult UpdateBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");

            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.UpdateBook(book);
            BookModel bookModel = new BookModel(book);
            return Ok(bookModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest("Id is Null");
            var response = _bookRepository.DeleteBook(id);
            return Ok(response);
        }
    }
}
