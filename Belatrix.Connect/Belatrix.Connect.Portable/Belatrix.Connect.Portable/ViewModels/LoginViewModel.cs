using System.Threading.Tasks;
using System.Windows.Input;
using Belatrix.Connect.Core.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Belatrix.Connect.Portable.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;

		private string _username;
		public string Username
		{
			get { return _username; }
			set
			{
				SetProperty(ref _username, value);
				RaiseCanExecuteChanged(ExecuteLoginCommand as DelegateCommand);
			}
		}

		private string _password;
		public string Password
		{
			get { return _password; }
			set
			{
				SetProperty(ref _password, value);
				RaiseCanExecuteChanged(ExecuteLoginCommand as DelegateCommand);
			}
		}

		public LoginViewModel()
		{
		}

		public LoginViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		private ICommand _executeLoginCommand;

		public ICommand ExecuteLoginCommand => 
			_executeLoginCommand ?? (_executeLoginCommand = new DelegateCommand(async () => { await Login(); }, CanExecuteLogin));

		private bool CanExecuteLogin()
		{
			return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
		}

		private async Task Login()
		{
			var authenticationResponse = await new EmployeeService().Authenticate(Username, Password);

			if (!authenticationResponse.IsValidUser)
			{
				//TODO: Show error to user
				return;
			}

			if (!authenticationResponse.IsBaseProfileComplete)
			{
				//TODO: Navigate to employee edit profile
				return;
			}

			//TODO: Navigate to main page
		}
	}
}
