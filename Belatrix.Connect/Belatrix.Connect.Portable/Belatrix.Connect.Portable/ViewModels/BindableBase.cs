using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Belatrix.Connect.Portable.ViewModels
{
	public class ViewModelBase : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;

		public ViewModelBase()
		{
		}

		public ViewModelBase(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		protected void RaiseCanExecuteChanged(DelegateCommandBase command)
		{
			command.RaiseCanExecuteChanged();
		}

		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{
			
		}
	}
}