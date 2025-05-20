using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.TestBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Tests
{
    public class AccountRegistrationTest : BaseClass
    {
       
        [Test]
        public void VerifyAccountRegistration()
        {
            HomePage hp = new HomePage(driver);
            hp.clickLinkMyAccount();
            
            Thread.Sleep(2000);

            hp.clickLinkRegister();

            AccountRegistrationPage ar  = new AccountRegistrationPage(driver);

            string firstName = RandomString();
            string lastName = RandomString();
            string email = $"{firstName}.{lastName}@gmail.com";
            string phone = RandomNumeric();
            string password = RandomAlphaNumeric();

            ar.setFirstName(firstName);
            ar.setLastName(lastName);
            ar.setEmail(email);
            ar.setTelephone(phone);
            ar.setPassword(password);
            ar.setConfirmPassword(password);
            ar.setGender();
            ar.setPolicy();
            ar.clickContinue();

            //var headers = ar.checkHeaders();
            //Assert.That("Qafox.com", headers.checkTextHeader);
            //Assert.That("Your Account Has Been Created!", headers.checkTextConfirmation);

            var (header, confirmation) = ar.checkHeaders();
            Assert.That("Qafox.com", Is.EqualTo(header));
            Assert.That("Your Account Has Been Created!", Is.EqualTo(confirmation));
            

            Console.WriteLine("===> Successful");
        }
    }
}
