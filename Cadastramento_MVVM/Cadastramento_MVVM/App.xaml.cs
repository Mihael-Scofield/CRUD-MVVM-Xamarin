using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cadastramento_MVVM.Services;
using Cadastramento_MVVM.Models;
using System.Linq;
using Cadastramento_MVVM.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cadastramento_MVVM {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            /* Aplica Injeção de Dependência nos serviços implementados */
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();            

            MainPage = new NavigationPage(new ClientListPage());
            // OnStart();
        }

        protected override void OnStart() {
            // var dbPath = new DbConfig().GetDbPath(); // Pega as conf. de onde está o Bd.
            // using (var db = new AppDbContext(dbPath)) { // Passa o contexto para "db", onde está meu Danco de Dados.
            //     db.Database.EnsureCreated(); // Verifica se o bd foi criado.
            //     var clientlist = db.Clients.OrderBy(c => c.Id);
            // }
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
