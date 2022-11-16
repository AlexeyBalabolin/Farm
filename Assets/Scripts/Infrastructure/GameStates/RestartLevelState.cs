using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameStates
{
    public class RestartLevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private ISaveLoadService _saveLoadService;

        public RestartLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IGameFactory gameFactory, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressSavers)
                progressReader.LoadProgress(_saveLoadService.Progress);
        }
    }
}
