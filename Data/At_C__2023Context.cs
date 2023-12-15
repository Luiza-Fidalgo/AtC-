using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using At_C__2023.Models;

namespace At_C__2023.Data
{
    public class At_C__2023Context : DbContext
    {
        public At_C__2023Context (DbContextOptions<At_C__2023Context> options)
            : base(options)
        {
        }

        public DbSet<At_C__2023.Models.Flor> Flor { get; set; }

        public DbSet<At_C__2023.Models.Vaso>? Vaso { get; set; }
    }
}
