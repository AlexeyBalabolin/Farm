using Infrastructure.GameStates;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _gameStateMachine;

        [SerializeField]
        private CurtainLoader _curtainLoader;
        [SerializeField]
        private AllPlants _plantsList;

        // точка входа в игру
        private void Awake()
        {
            _gameStateMachine = new GameStateMachine(new SceneLoader(this), ServiceLocator.Container, this, _curtainLoader, _plantsList);
            _gameStateMachine.Enter<BootstrapState>();//входим в начальное состояние
            DontDestroyOnLoad(this);
        }
    }
}