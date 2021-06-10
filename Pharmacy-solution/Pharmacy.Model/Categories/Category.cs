using Pharmacy.Model.Products;
using System.Collections.Generic;

namespace Pharmacy.Model.Categories
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }        
    }
}