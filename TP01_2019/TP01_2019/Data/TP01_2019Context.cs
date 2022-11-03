using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP01_2019.Models;

namespace TP01_2019.Data
{
    public class TP01_2019Context : DbContext
    {
        public TP01_2019Context (DbContextOptions<TP01_2019Context> options)
            : base(options)
        {
        }

        public DbSet<TP01_2019.Models.Carro> Carro { get; set; } = default!;
        public DbSet<TP01_2019.Models.Piloto> Piloto { get; set; } = default!;
    }
}
