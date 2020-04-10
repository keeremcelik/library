using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Book
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Abstract { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public string ISBN { get; set; }    

        [UIHint("Date")]
        [Required(ErrorMessage= "Please select a date")]
        public DateTime PublishDate { get; set; }
        
        public int LanguageId { get; set; }
        public string PageCount { get; set; }
      
        public int TypeId { get; set; }
        public string Image { get; set; }
        public bool isApproved { get; set; }
        public bool isReaded { get; set; }
        public bool isFavorite { get; set; }

        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]        
        public Decimal Price { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        
    }
}
