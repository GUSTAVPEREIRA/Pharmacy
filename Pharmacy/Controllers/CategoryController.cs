using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.DTO.Categories;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Services.IServices.Categories;
using System.Collections.Generic;
using System.Net;

namespace Pharmacy.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryService"></param>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [Authorize]
        public ActionResult<CategoryDTO> CreateCategory(NewCategoryDTO dto)
        {
            try
            {
                var newCategory = _categoryService.CreateCategory(dto);

                return new OkObjectResult(new
                {
                    Message = "Categoria criada!",
                    Code = HttpStatusCode.OK,
                    Result = newCategory
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }


        /// <summary>
        /// Get one category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [Authorize]
        public ActionResult<CategoryDTO> GetCategory(int id)
        {
            try
            {
                var categoryDTO = _categoryService.FindByIdCategory(id);

                return new OkObjectResult(new
                {
                    Message = "Categoria obtida!",
                    Code = HttpStatusCode.OK,
                    Result = categoryDTO
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }


        /// <summary>
        /// Updated one category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [Authorize]
        public ActionResult<CategoryDTO> UpdateCategory(CategoryDTO dto)
        {
            try
            {
                var categoryDTO = _categoryService.UpdateCategory(dto);

                return new OkObjectResult(new
                {
                    Message = "Categoria atualizada!",
                    Code = HttpStatusCode.OK,
                    Result = categoryDTO
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// Delete one category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public ActionResult<dynamic> DeleteCategory(int id)
        {
            try
            {
                _categoryService.DeletedCategoryById(id);

                return new OkObjectResult(new
                {
                    Message = $"Categoria {id} deletada",
                    Code = HttpStatusCode.OK,                    
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// List All categories by these parameters 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [Authorize]
        public ActionResult<List<CategoryDTO>> ListCategoryId(int page, int size, string name, int id)
        {
            try
            {
                var listCategoryDTO = _categoryService.ListCategoryByParameters(name, id, size, page);

                return new OkObjectResult(new
                {
                    Message = "Categoria atualizada!",
                    Code = HttpStatusCode.OK,
                    Result = listCategoryDTO
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }
    }
}