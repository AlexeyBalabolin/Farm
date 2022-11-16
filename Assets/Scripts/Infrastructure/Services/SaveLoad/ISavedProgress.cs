using Infrastructure.Data;

namespace Infrastructure.Services
{
    //реализуем этот интерфейс на компонентах, состояние которых хотим сохранять
    public interface ISavedProgress
    {
        void SaveProgress(PlayerProgress progress);
        void LoadProgress(PlayerProgress progress);
    }
}



