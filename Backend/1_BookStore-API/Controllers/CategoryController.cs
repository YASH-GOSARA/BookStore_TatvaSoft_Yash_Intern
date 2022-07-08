using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Book_e_Sale.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly CategoryRepository _categoryRepository = new CategoryRepository();

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<CategoryModel>), (int)System.Net.HttpStatusCode.OK)]
        public IActionResult GetCategories(string? keyword, int pageIndex = 1, int pageSize = 10)
        {
            var categories = _categoryRepository.GetCategories(keyword, pageIndex, pageSize);
            ListResponse<CategoryModel> listResponse = new ()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };
            return Ok(listResponse); 

        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CategoryModel), (int)System.Net.HttpStatusCode.OK)]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categoryModel = new(category);
            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(CategoryModel), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult AddCategory(CategoryModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");

            Category category = new()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel = new(response);
            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(CategoryModel), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");

            Category category = new()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel = new(response);
            
            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)System.Net.HttpStatusCode.BadRequest)]
        public IActionResult DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest("Id is Null");
            
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}