using FX;
using GlobalConstants;
using Infrastructure.Factory;
using Infrastructure.Services;
using Player;
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

            GameObject camera = _gameFactory.CreateFromResource(ResourcesConstants.CAMERA);
            _gameFactory.Camera = camera;
            camera.transform.position = player.transform.position + camera.GetComponent<CameraOffset>().OffsetVector;
            camera.transform.position += new Vector3(_gameFactory.MapSize.x/2, 0, -_gameFactory.MapSize.y/2);

            GameObject hud = _gameFactory.CreateFromResource(ResourcesConstants.HUD);
            _gameFactory.Hud = hud;

            GameObject fxPooler = _gameFactory.CreateFromResource(ResourcesConstants.POOLER);
            _gameFactory.FxPooler = fxPooler;
            fxPooler.GetComponent<FxPooler>().InitalizeEffects();

            MapGenerator mapGenerator = _gameFactory.CreateFromResource(ResourcesConstants.MAP).GetComponent<MapGenerator>();
            mapGenerator.GenerateMap(_gameFactory.MapSize);

            FindAllSavers();
        }

        protected virtual void FindAllSavers()
        {
            foreach (var saver in Object.FindObjectsOfType<MonoBehaviour>().OfType<ISavedProgress>())
                _gameFactory.AddProgressSaver(saver);
        }
    }
}
