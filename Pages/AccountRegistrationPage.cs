using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OpenCart.Pages
{
    public class AccountRegistrationPage : BasePage
    {
        public AccountRegistrationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='input-firstname']")]
        IWebElement textFirstName;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-lastname']")]
        IWebElement textLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-email']")]
        IWebElement textEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-telephone']")]
        IWebElement textTelephone;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-password']")]
        IWebElement textPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='input-confirm']")]
        IWebElement textConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//label[@class='radio-inline']")]
        IList<IWebElement> radioButtonGender;

        [FindsBy(How = How.XPath, Using = "//input[@name='agree']")]
        IWebElement checkPolicy;

        [FindsBy(How = How.XPath, Using = "//input[@value='Continue']")]
        IWebElement buttonContinue;

        [FindsBy(How = How.XPath, Using = "//h1//a")]
        IWebElement textHeader;
        
        [FindsBy(How = How.XPath, Using = "//div[@id='content']//h1")]
        IWebElement textConfirmation;

        public void setFirstName(string firstName)
        {
            textFirstName.SendKeys(firstName);
        }

        public void setLastName(string LastName)
        {
            textLastName.SendKeys(LastName);    
        }

        public void setEmail(string email)
        {
            textEmail.SendKeys(email);
        }

        public void setTelephone(string phone)
        {
            textTelephone.SendKeys(phone);
        }

        public void setPassword(string password)
        {
            textPassword.SendKeys(password);
        }

        public void setConfirmPassword(string confirmPassword)
        {
            textConfirmPassword.SendKeys(confirmPassword);
        }

        public void setGender()
        {
            foreach (IWebElement gender in radioButtonGender)
            {
                Console.WriteLine($"===> {gender.Text}");

                if (gender.Text.Equals("Yes"))
                {
                    gender.Click();
                }
            }
        }

        public void setPolicy()
        {
            checkPolicy.Click();
        }

        public void clickContinue()
        {
            buttonContinue.Click();
        }

        public (string checkTextHeader, string checkTextConfirmation) checkHeaders() // use tuple concept
        {
            try
            {
                return (textHeader.Text, textConfirmation.Text);
            }

            catch (Exception e)
            {
                throw new ArgumentException($"{e.Message}");
            }
        }
    }
}
