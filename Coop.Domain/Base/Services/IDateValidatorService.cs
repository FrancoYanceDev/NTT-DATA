 

namespace Coop.Domain.Base.Services
{
    public interface IDateValidatorService
    {
        bool ValidateFormat(string Fecha);
        (int, int, int) Desglosar(string Fecha);
    }
}
