using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace products_categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}
        public string Name {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
        ///
        public List<Product> AllProducts {get;set;}
    }
}