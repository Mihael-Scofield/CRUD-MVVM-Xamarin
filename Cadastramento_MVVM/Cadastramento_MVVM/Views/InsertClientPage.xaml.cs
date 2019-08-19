using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cadastramento_MVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cadastramento_MVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InsertClientPage : ContentPage
	{
		public InsertClientPage ()
		{
			InitializeComponent ();
            BindingContext = new InsertClientViewModel();
		}
	}
}