using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Milionario.Models;

namespace Projeto_Milionario.Data
{
    public class Projeto_MilionarioContext : DbContext
    {
        public Projeto_MilionarioContext (DbContextOptions<Projeto_MilionarioContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto_Milionario.Models.Curso> Curso { get; set; } = default!;

        public DbSet<Projeto_Milionario.Models.Utilizador> Utilizador { get; set; }
    }
}
