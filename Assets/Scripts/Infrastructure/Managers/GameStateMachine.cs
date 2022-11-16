using Infrastructure.Factory;
using Infrastructure.GameStates;
using Infrastructure.Services;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;
        private ICoroutineRunner _coroutineRunner;
        private CurtainLoader _curtainLoader;

        public GameStateMachine(SceneLoader sceneloader, ServiceLocator services, ICoroutineRunner coroutineRunner, 
            CurtainLoader curtainLoader, AllPlants _plantsList)
        {
            _curtainLoader = curtainLoader;
            _coroutineRunner = coroutineRunner;
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneloader, services, _coroutineRunner, _plantsList),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.GetService<ISaveLoadService>()),
                [typeof(LoadMenuState)] = new LoadMenuState(this, sceneloader, services.GetService<IGameFactory>(), services.GetService<ISaveLoadService>(), _curtainLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneloader, services.GetService<IGameFactory>(),
                    services.GetService<ISaveLoadService>(), _curtainLoader),
                [typeof(GameLoopState)] = new GameLoopState(this),
                [typeof(RestartLevelState)] = new RestartLevelState(this, sceneloader, services.GetService<IGameFactory>(), services.GetService<ISaveLoadService>())
            };
        }
        /// <summary>
        /// метод для входа в состояние
        /// </summary>
        /// <typeparam name="TState">состояние</typeparam>
        public void Enter<TState>() where TState:class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            //выход из активного состояния машины, если активное состояние !=null
            _activeState?.Exit();

            //новое состояние типа TState
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
