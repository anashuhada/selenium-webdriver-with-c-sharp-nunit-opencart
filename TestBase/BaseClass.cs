using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace OpenCart.TestBase
{
    public class BaseClass
    {

        public IWebDriver driver;
        private static Random ran = new Random();

        [SetUp]
        public void SetUp()
        {
            string? br = TestContext.Parameters["browser"];

            switch(br.ToLower())
            {
                case "chrome" : driver = new ChromeDriver(); break;
                case "edge" : driver = new EdgeDriver(); break;
                case "firefox" : driver = new FirefoxDriver(); break;
                default : throw new ArgumentException($"Unsupported browser detected: {br}"); return;
            }

            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/");
            driver.Navigate().GoToUrl(TestContext.Parameters["app_url"]);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int length = 10;
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[ran.Next(chars.Length)]);
            }

            return sb.ToString();

        }

        public string RandomNumeric()
        {
            const string num = "0123456789";
            int length = 10;
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(num[ran.Next(num.Length)]);
            }

            return sb.ToString();

        }

        public string RandomAlphaNumeric()
        {
            string generatedString = RandomString();
            string generatedNumeric = RandomNumeric();
            return generatedString + "_" + generatedNumeric;
        }
    }
}
