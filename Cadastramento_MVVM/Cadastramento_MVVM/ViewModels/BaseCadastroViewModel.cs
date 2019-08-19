using System;
using System.Collections.Generic;
using System.Text;
using Cadastramento_MVVM.Services;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Cadastramento_MVVM.Models;
using System.Linq;

namespace Cadastramento_MVVM.ViewModels {
    /* ViewModel Base, que ira ser herdada para as demais VMs */
    public class BaseCadastroViewModel : INotifyPropertyChanged {
        /* Declaração dos serviços e dos modelos usados */
        public Client _client;
        public IClientManipulation _clientManipulation;

        protected IMessageService _messageService;
        protected INavigationService _navigationService;

        /* Vinculo as dependencias dos serviços que irei utilizar, afim de desacoplar o código */
        public BaseCadastroViewModel() {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        /* --------------- NOTIFICAÇÕES DE MUDANÇA --------------- */
        public string Name {
            get => _client.Name; // Entrada vinculada ao dado sendo utilizado.
            set {
                _client.Name = value;
                NotifyPropertyChanged(nameof(Name)); //Sempre que houver alterações no nome dentr do Model, eu aviso para a VM.
            }
        }

        public int Age {
            get => _client.Age;
            set {
                _client.Age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }

        public string Phone {
            get => _client.Phone;
            set {
                _client.Phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }
        /* --------------- FIM: NOTIFICAÇÕES DE MUDANÇA --------------- */

        /* Declaração da Lista de Clientes */
        List<Client> _clientList;
        public List<Client> ClientList {
            get => _clientList;
            set {
                _clientList = value;
                NotifyPropertyChanged(nameof(ClientList));
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName="") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}