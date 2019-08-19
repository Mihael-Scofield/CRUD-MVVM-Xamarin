using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cadastramento_MVVM.Views;

namespace Cadastramento_MVVM.Services {
    public class NavigationService : INavigationService {
        /* Coloca no topo da pilha a página de Adicionar Cliente */
        public async Task NavigateToInsertClient() {
            await Cadastramento_MVVM.App.Current.MainPage.Navigation.PushAsync(new InsertClientPage());
        }

        /* Coloca no topo da pilha a página de Editar Cliente */
        public async Task NavigateToEditClient(int Id) {
            await Cadastramento_MVVM.App.Current.MainPage.Navigation.PushAsync(new EditClientPage(Id));
        }

        /* Coloca no topo da pilha a página que lista os clientes */
        public async Task NavigateToClientList() {
            await Cadastramento_MVVM.App.Current.MainPage.Navigation.PushAsync(new ClientListPage());
        }

        /* Retorna para a página anterior */
        public async void PopAsyncService() {
            await Cadastramento_MVVM.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
