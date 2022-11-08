using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashbaord.Infrastructure
{
    public class DateTimeProviderService : IDateTimeProviderService
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
