using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Model
{
    public class Apartment
    { 
       [Key]
       public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }
    }
}
