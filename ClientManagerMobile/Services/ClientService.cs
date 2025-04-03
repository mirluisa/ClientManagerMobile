using System.Collections.ObjectModel;
using ClientManagerMobile.Models;

namespace ClientManagerMobile.Services;

public class ClientService
{
    public ObservableCollection<Client> GetClients()
    {
        return _clients;
    }

    public void Add(Client client)
    {
        _clients.Add(client);
    }

    public void Delete(int id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        if (client != null)
        {
            _clients.Remove(client);
        }
    }

    public void Update(Client updatedClient)
    {
        var existingClient = _clients.FirstOrDefault(c => c.Id == updatedClient.Id);
        if (existingClient != null)
        {
            existingClient.Age = updatedClient.Age;
            existingClient.Name = updatedClient.Name;
            existingClient.Address = updatedClient.Address;
        }
    }

    private ObservableCollection<Client> _clients = new();
}
