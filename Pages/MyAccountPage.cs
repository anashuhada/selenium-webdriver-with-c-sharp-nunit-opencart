using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OpenCart.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[normalize-space()='My Account']")]
        IWebElement textHeader;
        
        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='My Account']")]
        IWebElement linkMyAccount;

        [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-menu dropdown-menu-right']//a[normalize-space()='Logout']")]
        IWebElement buttonLogout;

        public bool isMyAccountPageExist()
        {
            try
            {
                return textHeader.Displayed;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public void clicMyAccount()
        {
            js.ExecuteScript("arguments[0].click();", linkMyAccount);
        }
        
        
        public void clickLogout()
        {
            js.ExecuteScript("arguments[0].click();", buttonLogout);
            //buttonLogout.Click();
        }

    }
}
