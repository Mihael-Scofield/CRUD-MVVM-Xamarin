using System;
using System.Collections.Generic;
using System.Text;
using Cadastramento_MVVM.Models;
using Cadastramento_MVVM.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cadastramento_MVVM.ViewModels {
    public class InsertClientViewModel : BaseCadastroViewModel {
        /* Declaração dos comandos possíveis da View */
        public ICommand InsertClientCommand { get; private set; }
        public ICommand CancelInsertionCommand { get; private set; }

        public InsertClientViewModel() {
            _client = new Client();
            _clientManipulation = new ClientManipulation();

            InsertClientCommand = new Command(async () => await InsertClient());
            CancelInsertionCommand = new Command(async () => await ShowClientList());
        }

        /* Método  responsável por interagir com o usuário através do botão de salvar */
        async Task InsertClient() {
            bool resposta = await _messageService.ShowAsyncBool("Salvar Cliente", "Deseja salvar os dados desse cliente?", "Sim", "Não");
            if (resposta) {
                _clientManipulation.InsertClient(_client); // Inserção propriamente dita.
                await _navigationService.NavigateToClientList(); // Retorno a página inicial.
            }
        }

        async Task ShowClientList() {
            bool resposta = await _messageService.ShowAsyncBool("Cancelar", "Deseja cancelar esse cadastramento?", "Sim", "Não");
            if (resposta) {
                await _navigationService.NavigateToClientList();
            }
        }
    }
}
