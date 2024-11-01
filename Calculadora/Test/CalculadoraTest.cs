using AventStack.ExtentReports;
using Calculadora.Genericos;
using Calculadora.PageObjects.Calculadora;
using NUnit.Framework;

using OpenQA.Selenium;
using System;
using System.Globalization;

namespace Calculadora.Test
{
    [TestFixture]
    public class CalculadoraTest: BaseTest
    {
        public double valorUno;
        public double valorDos;
        public int eleccion;
        public string operacion;
        public double suma;
        public double resta;
        public double multiplicacion;
        public double division;
        public string concatenar;
        [Test]
        public void Calcular()
        {
            CalculadoraPage calculadorapage = new CalculadoraPage(baseURL, driver);
            CargarJson cargarjson = new CargarJson();
            test = extent.CreateTest("Realizó el cálculo").Info("Se utiliza para realizar operaciones matemáticas");
            valorUno = cargarjson.datosCalculadora().valorUno;
            valorDos = cargarjson.datosCalculadora().valorDos;
            eleccion = cargarjson.datosCalculadora().eleccion;
            operacion = cargarjson.datosCalculadora().operacion[eleccion];
            try
            {
                calculadorapage.ingresarValores(valorUno, valorDos, operacion);
                switch (eleccion)
                {
                    case 0:
                        suma = valorUno + valorDos;
                        assertValue(suma,"resultado de la suma:");
                        break;
                    case 1:
                        resta = valorUno - valorDos;
                        assertValue(resta,"resultado de la resta:");
                        break;
                    case 2:
                        multiplicacion = valorUno * valorDos;
                        assertValue(multiplicacion,"resultado de la multiplicación:");
                        break;
                    case 3:
                        division = valorUno / valorDos;
                        assertValue(division,"resultado de la división:");
                        break;
                    case 4:
                        concatenar = valorUno + "" + valorDos;
                        assertValue(Convert.ToDouble(concatenar),"resultado de concatenar:");
                        break;
                }
                              
            }
            catch (System.Exception e)
            {
                string error = Convert.ToString(e);
                string file = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.Log(Status.Fail, "Error " + test.AddScreenCaptureFromBase64String(file) + error);
                Assert.Fail(error);
            }
        }
        public void assertValue(double operacion,string msj)
        {
            CalculadoraPage calculadorapage = new CalculadoraPage(baseURL, driver);
            test.Log(Status.Pass, "Se ingresaron los valores, valor uno: " + valorUno + " valor dos: " + valorDos +" "+msj+" " + calculadorapage.set_valorResultado().GetAttribute("value"));
            string numero = calculadorapage.set_valorResultado().GetAttribute("value");
            bool entero = true;
            char[] caracter = numero.ToCharArray();
            for (int i = 0; i < caracter.Length; i++)
            {
                if (caracter[i] == '.')
                {
                    entero = false;
                }
            }
            if (entero)
            {
                Assert.AreEqual(operacion, Convert.ToDouble(calculadorapage.set_valorResultado().GetAttribute("value")));
            }
            else
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                Assert.AreEqual(operacion.ToString(nfi), calculadorapage.set_valorResultado().GetAttribute("value"));
            }
        }
    }
}
