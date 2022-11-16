using Infrastructure;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BotAI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(BotAnimator))]
    public class BotStrategy : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField]
        private float _workingTime, _followingSpeed;

        [SerializeField]
        private NavMeshAgent _navMesh;

        [SerializeField]
        private BotAnimator _botAnimator;

        private Dictionary<Type, IBotStrategy> _startegies = new Dictionary<Type, IBotStrategy>();
        private IBotStrategy _activeStrategy;
        private Vector3 _target;
        public Vector3 Target 
        {
            get => _target;
            set
            {
                _target = value;
                _startegies[typeof(FollowingStrategy)] = new FollowingStrategy
                    (_navMesh, _botAnimator, _target, () => ActiveStrategy = _startegies[typeof(WorkingStrategy)], this);
                ActiveStrategy = _startegies[typeof(FollowingStrategy)];
            }
        }

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
            _navMesh.speed = _followingSpeed;
            _startegies = new Dictionary<Type, IBotStrategy>()
            {
                [typeof(IdleStrategy)] = new IdleStrategy(_navMesh, _botAnimator),
                [typeof(FollowingStrategy)] = new FollowingStrategy(_navMesh, _botAnimator, Target, () => ActiveStrategy = _startegies[typeof(WorkingStrategy)], this),
                [typeof(WorkingStrategy)] = new WorkingStrategy(_navMesh, _botAnimator, _workingTime, () => ActiveStrategy = _startegies[typeof(IdleStrategy)], this)
            };

            ActiveStrategy = _startegies[typeof(IdleStrategy)];
        }
    }
}

