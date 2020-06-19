using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace products_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        [Required]
        [MaxLength(45)]
        public string Name {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        [Range(0,Int32.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Price {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        ///
        public List<Association> AllCategories {get;set;}
    }
}