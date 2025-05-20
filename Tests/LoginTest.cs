using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages;
using OpenCart.TestBase;

namespace OpenCart.Tests
{
    public class LoginTest : BaseClass
    {
        [Test]
        public void VerifyLoginPage()
        {
            HomePage hp = new HomePage(driver);
            hp.clickLinkMyAccount();

            Thread.Sleep(2000);

            hp.clickLinkLogin();

            LoginPage lp = new LoginPage(driver);
            lp.setEmail(TestContext.Parameters["login_email"]);
            lp.setPassword(TestContext.Parameters["login_password"]);
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
            map.clickLogout();

        }
    }
}
