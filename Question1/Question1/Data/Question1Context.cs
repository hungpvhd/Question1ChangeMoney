using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Question1.Data;

namespace Question1.Models
{
    public class Question1Context : DbContext
    {
        public Question1Context (DbContextOptions<Question1Context> options)
            : base(options)
        {
        }

        public DbSet<Question1.Data.ChangeCurrency> ChangeCurrency { get; set; }
    }
}
