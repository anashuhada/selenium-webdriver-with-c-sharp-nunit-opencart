using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OpenCart.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='My Account']")]
        IWebElement linkMyAccount;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Register']")]
        IWebElement linkRegister;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Login']")]
        IWebElement linkLogin;

        public void clickLinkMyAccount()
        {
            //linkMyAccount.Click();
            js.ExecuteScript("arguments[0].click();", linkMyAccount);
        }

        public void clickLinkRegister() {
            //linkRegister.Click();
            js.ExecuteScript("arguments[0].click();", linkRegister);
        }

        public void clickLinkLogin()
        {
            //linkLogin.Click();
            js.ExecuteScript("arguments[0].click();", linkLogin);
        }

    }
}
