using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento_MVVM.Services {
    public class MessageService : IMessageService {
        /* Mensagem isolada */
        public async Task ShowAsync(string message) {
            // Pega a pagina do topo da pilha e joga um DisplayAlert que se mantém até o usuário interagir
            await Cadastramento_MVVM.App.Current.MainPage.DisplayAlert("Clientes", message, "Ok");
        }

        /* Mensagem com um botão de confirmação */
        public async Task ShowAsync(string title, string message, string text) {
            await Cadastramento_MVVM.App.Current.MainPage.DisplayAlert(title, message, text);
        }

        /* Mensagem com dois botões de confirmação */
        public async Task ShowAsync(string title, string message, string text1, string text2) {
            await Cadastramento_MVVM.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }

        /* Mensagem com dois botões de confirmação que retorna booleano */
        public async Task<bool> ShowAsyncBool(string title, string message, string text1, string text2) {
            return await Cadastramento_MVVM.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }
    }
}
