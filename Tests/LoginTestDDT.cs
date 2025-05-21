using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages;
using OpenCart.TestBase;
using OpenCart.Utilities;

namespace OpenCart.Tests
{
    public class LoginTestDDT : BaseClass
    {
        [Test, TestCaseSource(typeof(CSVDataReader), nameof(CSVDataReader.GetTestCaseData), new object[] { @"D:\SeleniumWithC#\OpenCart\TestData\OpenCartLoginDDT.csv" })]
        public void VerifyLoginDDTPage(UserData user) // string email, string password
        {
            HomePage hp = new HomePage(driver);
            hp.clickLinkMyAccount();

            Thread.Sleep(2000);

            hp.clickLinkLogin();

            GenerateReport("LoginTestDDT");
            LogInfo("Verify login using .csv file");

            try
            {
                LoginPage lp = new LoginPage(driver);
                lp.setEmail(user.Email);
                lp.setPassword(user.Password);
                lp.clickLogin();

                MyAccountPage map = new MyAccountPage(driver);
                var account = map.isMyAccountPageExist();
                if (account == true)
                {
                    Assert.That(account, Is.True);
                }
                else
                {
                    Assert.That(account, Is.False);
                }

                map.clicMyAccount();

                Thread.Sleep(1000);

                map.clickLogout();

                LogPass("Test passed");
            }

            catch (Exception ex)
            {
                LogFail("Test failed", "LoginTestDDT");
                Console.WriteLine($"Exception error: {ex.ToString}");
            }

         FlushReport();

        }
    }
}
