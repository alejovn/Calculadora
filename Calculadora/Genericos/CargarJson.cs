using Newtonsoft.Json;
using System.IO;

namespace Calculadora.Genericos
{
    class CargarJson
    {
        public POJO.CalculadoraData datosCalculadora()
        {
            var Json = JsonConvert.DeserializeObject<POJO.CalculadoraData>(File.ReadAllText(@"..\..\..\Data\Calculadora.json"));
            return Json;
        }
    }
}
