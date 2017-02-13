using System.Threading.Tasks;
using System.Windows.Input;
using Belatrix.Connect.Core.Dtos;
using Belatrix.Connect.Core.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Belatrix.Connect.Portable.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		private readonly IEmployeeService _employeeService;
		private readonly IPageDialogService _pageDialogService;

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

		private bool _isEditEnabled;

		public bool IsEditEnabled
		{
			get { return _isEditEnabled; }
			set { SetProperty(ref _isEditEnabled, value); }
		}

		public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEmployeeService employeeService) : base(navigationService)
		{
			_pageDialogService = pageDialogService;
			_employeeService = employeeService;
			_isLoginExecuting = false;
			IsEditEnabled = true;
		}

		private ICommand _executeLoginCommand;

		public ICommand ExecuteLoginCommand => 
			_executeLoginCommand ?? (_executeLoginCommand = new DelegateCommand(async () => { await Login(); }, CanExecuteLogin));

		private bool _isLoginExecuting;
		private bool CanExecuteLogin()
		{
			return (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password)) && !_isLoginExecuting;
		}

		private async Task Login()
		{
			SetBussy();
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
			SetBussyFinished();

			if (!authenticationResponse.IsValidUser)
			{
				await _pageDialogService.DisplayAlertAsync("Error", "Wrong username or password", "Ok");
				return;	
			}

			await App.Database.SaveAuthenticationResponse(authenticationResponse);

			await _pageDialogService.DisplayAlertAsync("Welcome", "Login succeded, data stored to sqllite", "Ok");

			if (!authenticationResponse.IsBaseProfileComplete)
			{
				//TODO: Navigate to employee edit profile
				return;
			}
		}

		protected override void SetBussy()
		{
			base.SetBussy();

			IsEditEnabled = false;
			_isLoginExecuting = true;
			RaiseCanExecuteChanged(ExecuteLoginCommand as DelegateCommand);
		}

		protected override void SetBussyFinished()
		{
			base.SetBussyFinished();

			IsEditEnabled = true;
			_isLoginExecuting = false;
			RaiseCanExecuteChanged(ExecuteLoginCommand as DelegateCommand);
		}
	}
}
