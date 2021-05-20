using AutoMapper;
using Pharmacy.DTO.Categories;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Infra.Repositories.IRepositories.Categories;
using Pharmacy.Model.Categories;
using Pharmacy.Services.IServices.Categories;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pharmacy.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDTO CreateCategory(NewCategoryDTO dto)
        {
            var category = _mapper.Map<NewCategoryDTO, Category>(dto);
            _categoryRepository.Save(category);
            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        public void DeletedCategoryById(int id)
        {
            var category = _categoryRepository.FindById(id);

            if (category == null)
            {
                throw new APIException($"Categoria com o ID {id} não encontrada!", HttpStatusCode.NotFound);
            }

            _categoryRepository.Delete(category);
        }

        public CategoryDTO FindByIdCategory(int id)
        {
            var category = FindCategoryById(id);
            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        public List<CategoryDTO> ListCategoryByParameters(string name, int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO UpdateCategory(CategoryDTO dto)
        {
            var category = FindCategoryById(dto.Id);
            category.Name = dto.Name;
            category.SubName = dto.SubName;

            _categoryRepository.Updated(category);
            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        private Category FindCategoryById(int id)
        {
            var category = _categoryRepository.FindById(id);

            if (category == null)
            {
                throw new APIException($"Categoria com o ID {id} não encontrada!", HttpStatusCode.NotFound);
            }

            return category;
        }
    }
}