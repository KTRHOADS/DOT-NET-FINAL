using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week14.Models
{
    public class Bishopric
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; }

    }
}
