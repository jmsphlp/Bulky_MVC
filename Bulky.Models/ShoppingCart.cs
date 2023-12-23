using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [ForeignKey("Productid")]
        [ValidateNever]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Range(0, 1000, ErrorMessage = "Please Enter a Value Between 1 and 1000")]
        public int Count { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }

        [NotMapped]
        public double Price { get; set; }

    }
}
