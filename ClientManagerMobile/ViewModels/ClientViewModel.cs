using System.Collections.ObjectModel;
using System.Windows.Input;
using ClientManagerMobile.Models;
using ClientManagerMobile.Services;

namespace ClientManagerMobile.ViewModels;

public class ClientViewModel : ViewModelBase
{
    public ClientViewModel(ClientService clientService, IDialogService dialogService)
    {
        _dialogService = dialogService;
        _clientService = clientService;
        LoadClients();

        AddCommand = new Command(AddEvent);
        RemoveCommand = new Command<Client>(RemoveEvent);
        UpdateCommand = new Command<Client>(UpdateEvent);
    }

    public int AgeView
    {
        get { return _ageView; }
        set
        {
            _ageView = value;
            OnPropertyChanged();
        }
    }

    public string NameView
    {
        get { return _nameView; }
        set
        {
            _nameView = value;
            OnPropertyChanged();
        }
    }

    public string AddressView
    {
        get { return _addressView; }
        set
        {
            _addressView = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Client> ClientsView
    {
        get { return _clientsView; }
        set
        {
            _clientsView = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand RemoveCommand { get; }
    public ICommand UpdateCommand { get; }

    private void LoadClients()
    {
        ClientsView = new ObservableCollection<Client>(_clientService.GetClients());
    }

    private async void AddEvent()
    {
        if (string.IsNullOrWhiteSpace(NameView))
        {
            await _dialogService.ShowAlertAsync("Erro", "Nome é obrigatório!", "OK");
            return;
        }

        if (AgeView <= 0)
        {
            await _dialogService.ShowAlertAsync("Erro", "Idade inválida!", "OK");
            return;
        }

        Client new_client = new Client();
        new_client.Id = ClientsView.Count + 1;
        new_client.Age = AgeView;
        new_client.Name = NameView;
        new_client.Address = AddressView;

        _clientService.Add(new_client);
        LoadClients();

        AgeView = 0;
        NameView = string.Empty;
        AddressView = string.Empty;

        await _dialogService.ShowAlertAsync("Sucesso", "Cliente adicionado!", "OK");
    }

    private async void RemoveEvent(Client client)
    {
        if (client != null)
        {
            _clientService.Delete(client.Id);
            ClientsView.Remove(client);
            await _dialogService.ShowAlertAsync("Sucesso", "Cliente removido!", "OK");
        }

    }

    // TODO: Implementar o update do cliente na View
    private void UpdateEvent(Client client)
    {
        if (client != null)
        {
            _clientService.Update(client);
            LoadClients();
        }
    }

    private int _ageView;
    private string _nameView = string.Empty;
    private string _addressView = string.Empty;
    private ObservableCollection<Client> _clientsView = new();
    private readonly ClientService _clientService;
    private readonly IDialogService _dialogService;
}
