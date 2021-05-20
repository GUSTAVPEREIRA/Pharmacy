using Pharmacy.DTO.Categories;
using System.Collections.Generic;

namespace Pharmacy.Services.IServices.Categories
{
    public interface ICategoryService
    {
        CategoryDTO CreateCategory(NewCategoryDTO dto);
        CategoryDTO UpdateCategory(CategoryDTO dto);
        CategoryDTO FindByIdCategory(int id);
        List<CategoryDTO> ListCategoryByParameters(string name, int id);
        void DeletedCategoryById(int id);
    }
}