using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP01_2018.Models;

namespace TP01_2018.Data
{
    public class TP01_2018Context : DbContext
    {
        public TP01_2018Context (DbContextOptions<TP01_2018Context> options)
            : base(options)
        {
        }

        public DbSet<TP01_2018.Models.Cliente> Cliente { get; set; } = default!;
    }
}
