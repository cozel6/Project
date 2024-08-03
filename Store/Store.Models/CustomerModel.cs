using Store.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class CustomerModel
    {

        public int Custid { get; set; }
        [Required]
        public string Companyname { get; set; } = null!;
        [Required]
        [MinLength(2)]
        public string Contactname { get; set; } = null!;
        [Required]
        [MinLength(2)]
        public string Contacttitle { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;

        public string? Region { get; set; }

        public string? Postalcode { get; set; }
        [Required, MinLength(2)]
        public string Country { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = null!;

        public string? Fax { get; set; }

    }
}
