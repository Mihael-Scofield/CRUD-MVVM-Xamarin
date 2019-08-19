using System;
using System.Collections.Generic;
using System.Text;
using Cadastramento_MVVM.Models;
using Cadastramento_MVVM.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cadastramento_MVVM.ViewModels {
    public class EditClientViewModel : BaseCadastroViewModel {
        /* Declaração dos comandos possíveis da View */
        public ICommand EditClientCommand { get; private set; }
        public ICommand DeleteClientCommand { get; private set; }

        /* Inicialização da VM */
        public EditClientViewModel(int selectedClientId) {
            _client = new Client();
            _client.Id = selectedClientId;
            _clientManipulation = new ClientManipulation();

            EditClientCommand = new Command(async () => await EditClient());
            DeleteClientCommand = new Command(async () => await DeleteClient());

            FoundClientDetails(selectedClientId);
        }

        void FoundClientDetails(int selectedClientId) {
            _client = _clientManipulation.GetClientDetails(selectedClientId);
        }

        async Task EditClient() {
            bool resposta = await _messageService.ShowAsyncBool("Editar Cliente", "Deseja editar as informações do Client?", "Sim", "Não");
            if (resposta) {
                _clientManipulation.EditClient(_client);
                _navigationService.PopAsyncService();
            }
        }

        async Task DeleteClient() {
            bool resposta = await _messageService.ShowAsyncBool("Remover Cliente", "Deseja Deletar as informações do Client?", "Sim", "Não");
            if (resposta) {
                _clientManipulation.DeleteClient(_client);
                _navigationService.PopAsyncService();
            }
        }
    }
}