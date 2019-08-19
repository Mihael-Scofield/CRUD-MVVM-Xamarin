using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento_MVVM.Services {
    public interface IMessageService {
        /* Mensagem isolada */
        Task ShowAsync(string message);

        /* Mensagem com um botão de confirmação */
        Task ShowAsync(string title, string message, string text1);

        /* Mensagem com dois botões de confirmação */
        Task ShowAsync(string title, string message, string text1, string text2);

        /* Mensagem com dois botões de confirmação que retorna booleano */
        Task<bool> ShowAsyncBool(string title, string message, string text1, string text2);
    }
}
