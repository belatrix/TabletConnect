using System.Threading.Tasks;
using System.Windows.Input;
using Belatrix.Connect.Core.Dtos;
using Belatrix.Connect.Core.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Belatrix.Connect.Portable.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		private readonly IEmployeeService _employeeService;

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

		public LoginViewModel(INavigationService navigationService, IEmployeeService employeeService) : base(navigationService)
		{
			_employeeService = employeeService;
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
			await ProcessAuthenticationResponse(await _employeeService.Authenticate(Username, Password));
		}

		public override async void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);

			var authenticationResponse = await App.Database.GetAuthenticationDataAsync();

			if (authenticationResponse == null)
			{
				return;
			}

			await ProcessAuthenticationResponse(authenticationResponse);
		}

		private async Task ProcessAuthenticationResponse(AuthenticationResponse authenticationResponse)
		{
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

			await App.Database.SaveAuthenticationResponse(authenticationResponse);
		}
	}
}
