using GlobalConstants;
using Infrastructure.Factory;
using Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class LoadLevelState : IPayState<string>
    {
        protected GameStateMachine _gameStateMachine;
        protected SceneLoader _sceneLoader;
        protected CurtainLoader _curtainLoader;
        protected readonly IGameFactory _gameFactory;
        protected ISaveLoadService _saveLoadService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, 
            IGameFactory gameFactory, ISaveLoadService saveLoadService, CurtainLoader curtainLoader)
        {
            _curtainLoader = curtainLoader;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
        }

        public virtual void Enter()
        {
            _curtainLoader.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load("Main", OnLoaded);
        }

        public void Enter(string payload)
        {
            _curtainLoader.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(payload, OnLoaded);
        }

        public virtual void Exit()
        {
            _curtainLoader.Hide();
        }

        public virtual void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        protected void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressSavers)
                progressReader.LoadProgress(_saveLoadService.Progress);
        }

        protected virtual void InitGameWorld()
        {
            GameObject player = _gameFactory.CreateFromResource(ResourcesConstants.PLAYER);
            _gameFactory.Player = player;

            GameObject hud = _gameFactory.CreateFromResource(ResourcesConstants.HUD);

            PlantsCreator plants = ServiceLocator.Container.GetService<PlantsCreator>();
            _gameFactory.AddProgressSaver(plants);

            FindAllSavers();
        }

        protected virtual void FindAllSavers()
        {
            foreach (var saver in Object.FindObjectsOfType<MonoBehaviour>().OfType<ISavedProgress>())
                _gameFactory.AddProgressSaver(saver);
        }
    }
}
