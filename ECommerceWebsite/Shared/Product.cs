﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebsite.Shared {
    public class Product {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "https://via.placeholder.com/300x300";
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProductVariant> Variants { get; set; }= new List<ProductVariant>();
        //public List<Edition> Editions { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
     // public int Views { get; set; }
        //[Column(TypeName="decimal(18,2)")]
        //public decimal Price { get; set; }
        //[Column(TypeName = "decimal(18,2)")]

        //public decimal OriginalPrice { get; set; }
    }
}
