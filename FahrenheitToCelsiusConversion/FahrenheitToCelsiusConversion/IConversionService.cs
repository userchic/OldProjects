using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FahrenheitToCelsiusConversion
{
    [ServiceContract(Namespace = "http://fahrenheittocelsiusconversion.azurewebsites.net/")]

    public interface IConversionService
    {
        [OperationContract]
        double FahrenheitToCelsius(double farenheitDegrees);

        [OperationContract]
        double CelsiusToFahrenheit(double celsiusDegrees);
    }
}
