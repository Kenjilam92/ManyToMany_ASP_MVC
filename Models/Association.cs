using System.ComponentModel.DataAnnotations;

namespace products_categories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId{get;set;}
        [Required]
        public int ProductId {get;set;}
        public Product ProductDetails {get;set;}
        [Required]
        public int CategoryId {get;set;}
        ///
        public Category CategoryDetails {get;set;}
    }
}