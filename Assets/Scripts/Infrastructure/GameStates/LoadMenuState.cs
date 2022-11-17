using GlobalConstants;
using Infrastructure.Factory;
using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class LoadMenuState : LoadLevelState
    {
        public LoadMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IGameFactory gameFactory, ISaveLoadService saveLoadService, CurtainLoader curtainLoader) 
            : base(gameStateMachine, sceneLoader, gameFactory, saveLoadService, curtainLoader) { }

        protected override void InitGameWorld()
        {
            if(_gameFactory.Player != null)
            {
                _gameFactory.DestroyObject(_gameFactory.Player);
                _gameFactory.Player = null;
            }

            GameObject menu = _gameFactory.CreateFromResource(ResourcesConstants.MENU);
            menu.GetComponent<MainMenu>().Construct(_gameStateMachine, _saveLoadService);
        }

        public override void Enter()
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load("Menu", OnLoaded);
        }

        public override void Exit()
        {
            
        }

        public override void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
        }
    }
}
