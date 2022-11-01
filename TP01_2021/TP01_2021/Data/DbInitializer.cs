using DB_al73891;
using TP01_2021.Models;

namespace TP01_2021.Data
{
    public class DbInitializer
    {
        private readonly TP01Context _context;
        public DbInitializer(TP01Context context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if(_context.Contacto.Any())
            {
                return;
            }

            var contactos = new Contacto[]
            {
                new Contacto{NickName="Jota", Nome="João Pereira",Email="jota@outlo.com"},
                new Contacto{NickName="Prof", Nome="Luís Barbosa",Email="Prof@outlo.com", Amigo=true},
                new Contacto{NickName="Padeira", Nome="Brites de Almeida",Email="padeira@outlo.com", Amigo=true},
                new Contacto{NickName="Tozé", Nome="António Silva",Email="toze@outlo.com"},
            };

            foreach(var c in contactos)
            {
                _context.Contacto.Add(c);
            };

            _context.SaveChanges();
        }
    }
}
