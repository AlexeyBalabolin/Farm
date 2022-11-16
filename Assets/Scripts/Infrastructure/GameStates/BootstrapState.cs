using Infrastructure.Factory;
using Infrastructure.Services;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private ServiceLocator _serviceLocator;
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private ICoroutineRunner _coroutineRunner;
        private AllPlants _plantsList;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services, 
            ICoroutineRunner coroutineRunner, AllPlants plantsList)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = services;
            _coroutineRunner = coroutineRunner;
            _plantsList = plantsList;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load("Initialization", onLoaded:EnterLoadProgressState);
        }
        public void Exit()
        {
           
        }

        private void EnterLoadProgressState() => _gameStateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            _serviceLocator.RegisterService<IAssetProvider>(implementation: new AssetProvider());
            _serviceLocator.RegisterService<IGameFactory>(implementation: new GameFactory(_serviceLocator.GetService<IAssetProvider>()));
            _serviceLocator.RegisterService<ISaveLoadService>(implementation: new SaveLoadService(_serviceLocator.GetService<IGameFactory>()));
            _serviceLocator.RegisterService(implementation: new PlantsCreator(_plantsList));
            _serviceLocator.RegisterService(implementation: new EventBus());
        }
    }
}
