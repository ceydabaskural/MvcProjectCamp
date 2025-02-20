using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.EntityLayer
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(500)]
        public string Detail1 { get; set; }

        [StringLength(1000)]
        public string Detail2 { get; set; }

        [StringLength(100)]
        public string ImageUrl1 { get; set; }

        [StringLength(100)]
        public string ImageUrl2 { get; set; }
        public bool IsActive { get; set; }
    }
}
