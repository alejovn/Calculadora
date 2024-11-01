using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace Calculadora.PageObjects.Calculadora
{
    [TestFixture]
    class CalculadoraPage : BasePage
    {
        private By txtvalorUno = By.Id("number1Field");
        private By txtvalorDos = By.Id("number2Field");
        private By btnCalcular = By.Id("calculateButton");
        private By valorResultado = By.Id("numberAnswerField");
        private By comboOperacion = By.Id("selectOperationDropdown");

        public IWebElement set_txtvalorUno() { return _webDriver.FindElement(txtvalorUno); }
        public IWebElement set_txtvalorDos() { return _webDriver.FindElement(txtvalorDos); }
        public IWebElement set_comboOperacion() { return _webDriver.FindElement(comboOperacion); }
        public IWebElement set_btnCalcular() { return _webDriver.FindElement(btnCalcular); }
        public IWebElement set_valorResultado() { return _webDriver.FindElement(valorResultado); }
        public CalculadoraPage(string url, IWebDriver driver) : base(url, driver)
        {

        }
        public void ingresarValores(double valorUno, double valorDos, string operacion)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            set_txtvalorUno().SendKeys(""+valorUno.ToString(nfi));
            set_txtvalorDos().SendKeys(""+valorDos.ToString(nfi));
            set_comboOperacion().Click();
            new SelectElement(set_comboOperacion()).SelectByText(operacion);
            set_btnCalcular().Click();
        }
    }
}
