using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP01_2021_v2.Models;

namespace EW_2021_PAP1_DB_al73891
{
    public class TP01Context : DbContext
    {
        public TP01Context (DbContextOptions<TP01Context> options)
            : base(options)
        {
        }

        public DbSet<TP01_2021_v2.Models.Livro> Livro { get; set; } = default!;
    }
}
