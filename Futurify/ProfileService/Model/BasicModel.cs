using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Model
{
    public class BasicModel
    {
        [Key]
        public int ID;
        public DateTime? CreateAt;
        public DateTime? UpdateAt;
    }
}
