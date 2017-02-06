using System;
using Belatrix.Connect.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.Connect.Core.Test.Services
{
	[TestClass]
	public class EmployeeServiceTest
	{
	    private const string Token = "3067d66937b4f18f36f01ce00fc7588b2fc39a3a";

        [TestMethod]
		public void Get_WithValidId_ShouldGetEmployeeData()
		{
			var service = new EmployeeService();

			service.AddToken(Token);
			var employee = service.Get(34).Result;

            Assert.AreEqual(34, employee.Id);
            Assert.AreEqual("mtopp", employee.UserName);
            Assert.AreEqual("mtopp@belatrixsf.com", employee.Email);

            if (employee.IsBaseProfileComplete)
            {
                Assert.AreEqual("Maximiliano", employee.FirstName);
                Assert.AreEqual("Topp", employee.LastName);
            }
            else
            {
                Assert.AreEqual(string.Empty, employee.FirstName);
                Assert.AreEqual(string.Empty, employee.LastName);
            }
		}
	}
}
