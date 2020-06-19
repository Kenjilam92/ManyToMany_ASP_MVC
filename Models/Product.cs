using System;
using System.ComponentModel.DataAnnotations;

namespace products_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        public string Name {get;set;}

        public string Description {get;set;}
        public decimal Price {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}