using Practica.Web.MinimalApi.Models;

namespace Practica.Web.MinimalApi.Data.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }
}
