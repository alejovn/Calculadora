using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Calculadora
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public string baseURL = "https://testsheepnz.github.io/BasicCalculator.html";
        public static ExtentTest test;
        public static ExtentReports extent;
        [SetUp]
        public void iniciarNavegador()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
        }
        [OneTimeSetUp]
        public void iniciarReporte()
        {
            extent = new ExtentReports();
            ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(@"..\..\..\Reportes\Tes" + this.GetType().ToString() + DateTime.Now.ToString("_ddMMyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void cerrarReporte()
        {
            extent.Flush();
        }
        [TearDown]
        public void cerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
