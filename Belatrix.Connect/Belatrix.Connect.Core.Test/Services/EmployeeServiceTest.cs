using System;
using Belatrix.Connect.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.Connect.Core.Test.Services
{
	[TestClass]
	public class EmployeeServiceTest
	{
		[TestMethod]
		public void Get_WithValidId_ShouldGetEmployeeData()
		{
			var service = new EmployeeService();

			var data = service.Authenticate("mtopp", "btt4").Result;

			service.AddToken(data.Token);
			var employee = service.Get(data.Id).Result;
		}
	}
}
