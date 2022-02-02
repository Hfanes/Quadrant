using ProjetoDeSia.Models;
using System.Linq;

namespace ProjetoDeSia.Data
{
    public class DbInitializer
    {
        //assegura que a base de dados é criada, se esta não existir ainda.
        public static void Initialize(ProjetoDeSiaContext context)
        {
            context.Database.EnsureCreated();


            //assegura que o admin master é criado logo quando a BD é criada tb
            if (context.Utilizador.Any())
            {
                return;
            }
            else
            {

                var admin = new Utilizador[]
                {
                    new Utilizador
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        Password = "12345",
                        Categoria = -1
                    }

                };

                foreach (Utilizador a in admin)
                {
                    context.Utilizador.Add(a);
                }
                context.SaveChanges();
            }
        }

        
    }
}
