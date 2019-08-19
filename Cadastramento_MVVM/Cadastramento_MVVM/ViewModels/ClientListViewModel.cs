using System;
using System.Collections.Generic;
using System.Text;

using Cadastramento_MVVM.Models;
using Cadastramento_MVVM.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cadastramento_MVVM.ViewModels {
    public class ClientListViewModel : BaseCadastroViewModel {
        /* Declaração dos comandos possíveis da View */
        public ICommand OrderByIdCommand { get; private set; }
        public ICommand OrderByNameCommand { get; private set; }
        public ICommand OrderByAgeCommand { get; private set; }
        public ICommand InsertClientCommand { get; private set; }

        /* Inicialização da VM */
        public ClientListViewModel() {
            _clientManipulation = new ClientManipulation();

            // Direcionamento para os métodos que tratam cada um dos comandos */
            OrderByIdCommand = new Command(OrderById);
            OrderByNameCommand = new Command(OrderByName);
            OrderByAgeCommand = new Command(OrderByAge);
            InsertClientCommand = new Command(async () => await ShowInsertClient());

            FillClientList();
        }

        /* --------------- Funções que tratam preenchimento da lista --------------- */
        void FillClientList() {
            ClientList = _clientManipulation.GetClientList();
        }

        /* Task que organizam minha página ou me enviam para outro lugar */
        async Task ShowInsertClient() {
            await _navigationService.NavigateToInsertClient();
        }

        void OrderById() {
            ClientList = _clientManipulation.OrderById();
        }

        void OrderByName() {
            ClientList = _clientManipulation.OrderByName();
        }

        void OrderByAge() {
            ClientList = _clientManipulation.OrderByAge();
        }

        /* --------------- Tratamento de seleção --------------- */
        Client _selectedClient; // Cria um vessel
        public Client SelectedClient {
            get => _selectedClient; // Faz sua declaração e pega os dados
            set {
                if (value != null) {
                    _selectedClient = value;
                    NotifyPropertyChanged("SelectedClient");
                    ExibirClientDetails(value.Id); // Redireciona para seus detalhes, afim de editar
                }
            }
        }

        async void ExibirClientDetails(int selectedClientID) {
            await _navigationService.NavigateToEditClient(selectedClientID);
        }

        /* --------------- Tratamento da barra de pesquisa --------------- */
        private ICommand _searchCommand; 
        public ICommand SearchCommand { // Comando responsável pela pesquisa
            get {
                // Retorna o comando pesquisado se não for null, se não, cria uma string nova "texto" e joga no comando.
                return _searchCommand ?? (_searchCommand = new Command<string>((text) => {
                    
                    /* Procedimento padrão de acesso ao bd */
                    var dbPath = new DbConfig().GetDbPath(); 
                    using (var db = new AppDbContext(dbPath)) {
                        var clientlist = db.Clients.OrderBy(c => c.Id).ToList(); // Ordenação padrão.

                        /* Pesquisa propriamente dita */
                        // Caso pesquisa seja por Id
                        if (text.Length >= 1) { // Existe pesquisa

                            if (int.TryParse(text, out int Id_s)) { // Pesquisa por Id
                                ClientList = clientlist.Where(i => i.Id.Equals(Id_s)).ToList();
                            }
                            else { // Pesquisa por Nome
                                ClientList = clientlist.Where(i => i.Name.Contains(text)).ToList();
                            }

                        }
                        else { // Não existe pesquisa
                            ClientList = clientlist; // Volto a ordenação original
                        }

                    }
                }));
            }
        }
    }

    /* Comportamento que faz a barra o tratamento do texto */
    public class TextChangedBehavior : Behavior<SearchBar> {
        protected override void OnAttachedTo(SearchBar bindable) {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable) {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e) {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}





