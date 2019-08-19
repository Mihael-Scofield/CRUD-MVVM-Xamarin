using System;
using System.Collections.Generic;
using System.Text;
using Cadastramento_MVVM.Services;
using Cadastramento_MVVM.Helpers;
using Cadastramento_MVVM.Models;
using System.Linq;

namespace Cadastramento_MVVM.Services {
    public class ClientManipulation : IClientManipulation {
        DbHelper _dbHelper; // Variável que "aponta" para DbHelper em Helpers.
        public ClientManipulation() {
            _dbHelper = new DbHelper(); // Faço essa ligação
        }

        /* Faz a inserção de Clientes no Bd */
        public void InsertClient(Client _client) {
            _dbHelper.InsertClient(_client);
        }

        /* Atualiza o cliente no Banco de Dados */
        public void EditClient(Client _client) {
            _dbHelper.EditClient(_client);
        }

        /* Deleta cliente no Banco de Dados */
        public void DeleteClient(Client _client) {
            _dbHelper.DeleteClient(_client);
        }

        /* Ordena a lista pelo Id */
        public List<Client> OrderById() {
            return _dbHelper.OrderById();
        }

        /* Ordena a lista pelo Nome */
        public List<Client> OrderByName() {
            return _dbHelper.OrderByName();
        }

        /* Ordena a lista pela Idade */
        public List<Client> OrderByAge() {
            return _dbHelper.OrderByAge();
        }

        /* Retorna a lista inteira de clientes */
        public List<Client> GetClientList() {
            return _dbHelper.GetClientList();
        }

        public Client GetClientDetails(int clientId) {
            return _dbHelper.GetClientDetails(clientId);
        }
    }
}
