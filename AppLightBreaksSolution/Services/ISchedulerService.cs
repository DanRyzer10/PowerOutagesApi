using AppLightBreaksSolution.DTOS;

namespace AppLightBreaksSolution.Services
{
    public interface ISchedulerService
    {
        Task<dynamic> Get(string DocumentNumber, string DocumentType);
    }
}
