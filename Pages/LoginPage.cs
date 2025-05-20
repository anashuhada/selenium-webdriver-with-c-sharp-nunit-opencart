using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OpenCart.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            //this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='input-email']")]
        IWebElement textEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-password']")]
        IWebElement textPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        IWebElement buttonLogin;
        
        public void setEmail(string email)
        {
            textEmail.SendKeys(email);
        }

        public void setPassword(string password)
        {
            textPassword.SendKeys(password);
        }

        public void clickLogin()
        {
            buttonLogin.Click();
        }
    }
}
