using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Factory;
using Infrastructure.Services;
using Player;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace BotAI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(BotAnimator))]
    public class BotStrategy : MonoBehaviour, ICoroutineRunner
    {
        public List<GameObject> PatrolPoints = new List<GameObject>();

        private float _walkingSpeed, _runningSpeed;

        [SerializeField]
        private float _lookAroundTime, _coolDownTime;
        [SerializeField]
        private float _followingStoppingDistance;
        [SerializeField]
        private NavMeshAgent _navMesh;
        [SerializeField]
        private BotAnimator _botAnimator;
        [SerializeField]
        private UnityEvent _onPlayerDie, _onPlayerRestart;

        private IBotStrategy[] _strategies;
        private IBotStrategy _activeStrategy;
        private IGameFactory _gameFactory;

        public IBotStrategy ActiveStrategy
        {
            get => _activeStrategy;
            set
            {
                _activeStrategy = value;
                _activeStrategy?.Execute();
            }
        }

        private void Start()
        {
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            _botAnimator.PlayIdle();
            _walkingSpeed = _complexityService.CurrentComplexityLevel.WalkingSpeed;
            _runningSpeed = _complexityService.CurrentComplexityLevel.RunningSpeed;
            _coolDownTime = _complexityService.CurrentComplexityLevel.CooldownTime;
            _botHearing.SphereRadius = _complexityService.CurrentComplexityLevel.HearingRadius;
            _strategies = new IBotStrategy[]
            {
                new FollowingStrategy(_walkingSpeed, _followingStoppingDistance, _navMesh, _botAnimator, PatrolPoints,() => ActiveStrategy = _strategies[1], this),
                new IdleStrategy(_botAnimator, _lookAroundTime, () => ActiveStrategy = _strategies[0], this),
                new WorkingStrategy()
            };
            ActiveStrategy = _strategies[0];
            AttackStrategy.Reset();
            _onPlayerRestart?.Invoke();
        }
    }
}

