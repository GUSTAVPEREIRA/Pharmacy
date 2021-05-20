﻿using System.ComponentModel.DataAnnotations;

namespace Pharmacy.DTO.Categories
{
    public class NewCategoryDTO
    {
        [Required(ErrorMessage = "O nome é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo nome não pode ser maior que 100 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O subname é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo subname não pode ser maior que 100 caracteres!")]
        public string Subname { get; set; }
    }
}