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

		private bool _isBusy;

		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				SetProperty(ref _isBusy, value);
			}
		}

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

		protected virtual void SetBussy()
		{
			IsBusy = true;
		}

		protected virtual void SetBussyFinished()
		{
			IsBusy = false;
		}
	}
}