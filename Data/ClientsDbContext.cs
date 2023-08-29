using Microsoft.EntityFrameworkCore;
using Practica.Web.MinimalApi.Models;

namespace Practica.Web.MinimalApi.Data
{
    public class ClientsDbContext : DbContext
    {
        public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
        {
            FillClients();
        }

        public DbSet<Client> Clients { get; set; }

        private void FillClients()
        {
            if (Clients.Count() == 0)
            {
                Clients.Add(new Client { Id = 1, Name = "Juan", LastName = "Pérez", Address = "Fotheringham 588" });
                Clients.Add(new Client { Id = 2, Name = "Antonio", LastName = "Ripoll", Address = "Italia 1402" });
                Clients.Add(new Client { Id = 3, Name = "Clara", LastName = "Campi", Address = "Brandzen 19" });
                SaveChanges();
            }
        }
    }
}
