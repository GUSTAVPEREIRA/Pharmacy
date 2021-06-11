using Pharmacy.Model.Categories;
using System;

namespace Pharmacy.Model.Products
{
    public class Product
    {
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
            Update();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }        
        public Category Category { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool Prescrition { get; set; }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void Disable()
        {
            DeletedAt = DateTime.UtcNow;
            Update();
        }

        public void Enable()
        {
            DeletedAt = null;
            Update();
        }
    }
}