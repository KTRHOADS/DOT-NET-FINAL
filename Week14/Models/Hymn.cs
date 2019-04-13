using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week14.Models
{
    public class Hymn
    {
        public int ID { get; set; }
        [Display(Name = "Hymn Number")]
        public int HymnNumber { get; set; }
        [Display(Name = "Hymn Title")]
        public string Title { get; set; }
    }
}
