using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento_MVVM.Services {
    public interface INavigationService {
        /* Coloca no topo da pilha a página de Adicionar Cliente */
        Task NavigateToInsertClient();

        /* Coloca no topo da pilha a página de Editar Cliente */
        Task NavigateToEditClient(int Id);

        /* Coloca no topo da pilha a página que lista os clientes */
        Task NavigateToClientList();

        /* Retorna para a página anterior */
        void PopAsyncService();
    }
}
