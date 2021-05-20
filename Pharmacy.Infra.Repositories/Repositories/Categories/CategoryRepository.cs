﻿using Pharmacy.Infra.Data;
using Pharmacy.Infra.Repositories.IRepositories.Categories;
using Pharmacy.Model.Categories;

namespace Pharmacy.Infra.Repositories.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
            base.Context = context;
        }
    }
}