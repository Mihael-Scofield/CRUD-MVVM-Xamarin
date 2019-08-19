using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cadastramento_MVVM.ViewModels;

namespace Cadastramento_MVVM.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClientPage : ContentPage {
        public EditClientPage(int clientID) {
            InitializeComponent();
            this.BindingContext = new EditClientViewModel(clientID);
        }
    }
}