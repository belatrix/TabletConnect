using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Connect.Portable.Model
{
	public class LoginModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public bool IsValid
		{
			get { return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password); }
		}
	}
}
