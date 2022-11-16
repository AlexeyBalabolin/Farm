using Infrastructure.Data;

namespace Infrastructure.Services
{
    public interface ISaveLoadService:IService
    {
        PlayerProgress Progress { get; set; }
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
