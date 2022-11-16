using Infrastructure.Data;
using Infrastructure.Services;

namespace Infrastructure.GameStates
{
    public class LoadProgressState : IState
    {
        private GameStateMachine _gameStateMachine;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadMenuState>();
        }

        public void Exit() { }

        private void LoadProgressOrInitNew() => _saveLoadService.Progress = _saveLoadService.LoadProgress() ?? CreateNewProgress();

        private PlayerProgress CreateNewProgress()
        {
            var progress = new PlayerProgress();
            return progress;
        }
    }
}
