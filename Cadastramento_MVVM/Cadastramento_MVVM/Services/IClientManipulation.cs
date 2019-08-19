using System;
using System.Collections.Generic;
using System.Text;
using Cadastramento_MVVM.Models;
using System.Linq;

namespace Cadastramento_MVVM.Services {
    public interface IClientManipulation {
        /* Faz a inserção de Clientes no Bd */
        void InsertClient(Client _client);

        /* Atualiza o cliente no Banco de Dados */
        void EditClient(Client _client);

        /* Deleta cliente no Banco de Dados */
        void DeleteClient(Client _client);

        /* Ordena a lista pelo Id */
        List<Client> OrderById();

        /* Ordena a lista pelo Nome */
        List<Client> OrderByName();

        /* Ordena a lista pela Idade */
        List<Client> OrderByAge();

        List<Client> GetClientList();

        Client GetClientDetails(int clientId);
    }
}
