using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public IJavaScriptExecutor js;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            js = (IJavaScriptExecutor)driver;
        }
    }
}
