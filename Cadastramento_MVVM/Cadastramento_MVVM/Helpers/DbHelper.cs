using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadastramento_MVVM.Models;

namespace Cadastramento_MVVM.Helpers {
    class DbHelper {

        /* Faz a inserção de Clientes no Bd */
        public void InsertClient(Client _client) {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                var nclient = _client; // Cliente novo;
                var empty = db.Clients.Any(); // Verifico se a tabela está vázia
            
                if (!empty) {
                    nclient.Id = 1;
                    db.Add(new Client() { Name = nclient.Name, Id = nclient.Id, Age = nclient.Age, Phone = nclient.Phone });
                }
                else {
                    var lclient = db.Clients.Last();
                    nclient.Id = (lclient.Id + 1);
                    db.Add(new Client() { Name = nclient.Name, Id = nclient.Id, Age = nclient.Age, Phone = nclient.Phone });
                }
                db.SaveChanges();
            }
        }

        /* Atualiza o cliente no Banco de Dados */
        public void EditClient(Client _client) {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                /* contextualização */
                var ctx_client = _client; // Recebo o cliente do contexto externo (Main)
                var edit_client = db.Clients.Find(ctx_client.Id); // Faço a vinculação com o cliente interno (Tabela)
            
                /* Atualização */
                edit_client.Name = ctx_client.Name;
                edit_client.Age = ctx_client.Age;
                edit_client.Phone = ctx_client.Phone;
            
                db.SaveChanges();
            }
        }

        /* Deleta cliente no Banco de Dados */
        public void DeleteClient(Client _client) {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                var dclient = _client;
                db.Clients.Remove(dclient);
                db.SaveChanges();
            }
        }

        /* Ordena a lista pelo Id */
        public List<Client> OrderById() {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                var clientlist = db.Clients.OrderBy(c => c.Id).ToList();
                return clientlist;               
            }
        }

        /* Ordena a lista pelo Nome */
        public List<Client> OrderByName() {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                var clientlist = db.Clients.OrderBy(c => c.Name).ToList();
                return clientlist;
            }
        }

        /* Ordena a lista pela Idade */
        public List<Client> OrderByAge() {
            var dbPath = new DbConfig().GetDbPath();
            using (var db = new AppDbContext(dbPath)) {
                var clientlist = db.Clients.OrderBy(c => c.Age).ToList();
                return clientlist;
            }
        }

        /* Retorna a lista inteira de clientes */
        public List<Client> GetClientList() {
            var dbPath = new DbConfig().GetDbPath(); // Pega as configurações de onde está o bd

            using (var db = new AppDbContext(dbPath)) { // Passa o contexto para "db", onde está meu Banco de Dados
                db.Database.EnsureCreated(); // Verifica se o banco de fato foi criado.                
                var clientlist = db.Clients.OrderBy(c => c.Id).ToList();
                return clientlist;
            }
        }

        public Client GetClientDetails(int clientId) {
            var dbPath = new DbConfig().GetDbPath();

            using (var db = new AppDbContext(dbPath)) { 
                db.Database.EnsureCreated(); 
                var client = db.Clients.Find(clientId); // Procura cliente específico.
                return client;
            }
        }
    }
}