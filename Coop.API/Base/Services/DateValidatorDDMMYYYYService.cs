using Coop.Domain.Base.Services;
using System.Text.RegularExpressions;

namespace Coop.API.Base.Services
{
    public class DateValidatorDDMMYYYYService : IDateValidatorService
    {
        Regex regex;

        public bool ValidateFormat(string Fecha)
        {
            this.regex = new Regex(@"^([1-9]|[0-2][0-9]|3[0-1])/([1-9]|0[1-9]|1[0-2])/[0-9]{4}$");
            return regex.Match(Fecha).Success;
        }

        public (int, int, int) Desglosar(string Fecha)
        {
            string[] dateList = Fecha.Split("/");

            int dia = Convert.ToInt32(dateList[0]);
            int mes = Convert.ToInt32(dateList[1]);
            int anio = Convert.ToInt32(dateList[2]);

            return (dia, mes, anio);
        }
    }
}
