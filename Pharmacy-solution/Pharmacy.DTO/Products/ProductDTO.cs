using Pharmacy.DTO.Categories;
using System;

namespace Pharmacy.DTO.Products
{
    public class ProductDTO : BaseProductDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public ProductDTO()
        {
            Category = new CategoryDTO();            
        }
    }
}
