using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenCart.Pages;
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
        private ExtentReports report;
        private ExtentTest test;
        private readonly string reportPath = @"D:\SeleniumWithC#\OpenCart\Reports\";
        private readonly string screenshotPath = @"D:\SeleniumWithC#\OpenCart\Screenshots\";

        [SetUp]
        public void SetUp()
        {
            string? br = TestContext.Parameters["browser"] ?? "chrome";
            string? appUrl = TestContext.Parameters["app_url"] ?? "https://tutorialsninja.com/demo/";

            switch (br.ToLower())
            {
                case "chrome" : driver = new ChromeDriver(); break;
                case "edge" : driver = new EdgeDriver(); break;
                case "firefox" : driver = new FirefoxDriver(); break;
                default : Console.WriteLine($"Unsupported browser detected: {br}"); return;
            }

            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/");
            driver.Navigate().GoToUrl(appUrl);
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

        public void GenerateReport(string testName)
        {
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            string fileName = testName + DateTime.Now.ToString("_MMddyyyy_HHmmss") + ".html";
            var htmlReport = new ExtentSparkReporter(Path.Combine(reportPath, fileName));
            report = new ExtentReports();
            report.AttachReporter(htmlReport);
            test = report.CreateTest(testName);
        }

        public void LogInfo(string message)
        {
            test?.Info(message);
        }

        public void LogPass(string message)
        {
            test?.Pass(message);
        }

        public string CaptureScreenshot(string screenshotName)
        {
           string fileName = screenshotName + DateTime.Now.ToString("_MMddyyyy_HHmmss") + ".png";
           string capturePath = Path.Combine(screenshotPath, fileName);
        
            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                ts.GetScreenshot().SaveAsFile(capturePath);
                Console.WriteLine($"Screenshot saved at {capturePath}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Screenshot Error: {ex.ToString}");
            }
            
            return capturePath;
        
        }

        public void FlushReport()
        {
            report?.Flush();
        }

        public void LogFail(string message, string screenshotName)
        {
            test?.Fail(message);

            string path = CaptureScreenshot(screenshotName);

            try
            {
                if (File.Exists(path))
                {
                    test?.AddScreenCaptureFromPath(path);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine($"No screenshot: {e.ToString()}");
            }

        }
    }
}
