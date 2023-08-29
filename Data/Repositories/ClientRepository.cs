using Practica.Web.MinimalApi.Data.Interfaces;
using Practica.Web.MinimalApi.Models;
using System.Runtime.CompilerServices;

namespace Practica.Web.MinimalApi.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsDbContext _dbContext;

        public ClientRepository(ClientsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _dbContext.Clients;
        }

        public Client GetClientById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public void CreateClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c =>c.Id == id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
        }
    }
}
