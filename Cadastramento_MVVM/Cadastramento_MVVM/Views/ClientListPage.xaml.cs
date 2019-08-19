using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cadastramento_MVVM.ViewModels;

namespace Cadastramento_MVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientListPage : ContentPage
	{
		public ClientListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing() {
            this.BindingContext = new ClientListViewModel();
        }
    }
}