using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Question1.Data
{
    public class ChangeCurrency
    {
        [Key]
        public int Id { get; set; }
        public int ratio { get; set; }
    }
}
