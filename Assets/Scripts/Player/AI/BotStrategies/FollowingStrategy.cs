using Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BotAI
{
    public class FollowingStrategy : IBotStrategy
    {
        public event Action OnChangeStrategy;

        protected float _stoppingDistance;
        protected float _speed;
        protected NavMeshAgent _navMeshAgent;
        protected BotAnimator _botAnimator;
        protected List<GameObject> _targets;
        protected ICoroutineRunner _coroutineRunner;
        protected readonly float _checkTime = 0.5f;
        protected readonly float _distanceEps = 1f;

        private int _targetIndex = 0;

        public FollowingStrategy()
        {
                
        }

        public FollowingStrategy(float speed, float stoppingDistance, NavMeshAgent navMeshAgent, BotAnimator botAnimator, 
            List<GameObject> targets, Action onCameToPoint, ICoroutineRunner coroutineRunner)
        {
            _speed = speed;
            _stoppingDistance = stoppingDistance;
            _navMeshAgent = navMeshAgent;
            _botAnimator = botAnimator;
            _targets = targets;
            _coroutineRunner = coroutineRunner;
            OnChangeStrategy = onCameToPoint;
        }

        public virtual void Execute()
        {
            _navMeshAgent.speed = _speed;
            _navMeshAgent.SetDestination(SelectNextTarget().transform.position);
            _navMeshAgent.stoppingDistance = _stoppingDistance;
            _coroutineRunner.StartCoroutine(Following());
        }

        protected virtual GameObject SelectNextTarget()
        {
            _targetIndex = _targetIndex < _targets.Count-1 ? _targetIndex + 1 : 0;
            return _targets[_targetIndex];
        }

        protected virtual IEnumerator Following()
        {
            while(true)
            {
                yield return new WaitForSeconds(_checkTime);
                if (CheckRemainingDistance())
                    break;
            }
        }

        protected bool CheckRemainingDistance()
        {
            _botAnimator.Move(_navMeshAgent.velocity.magnitude);
            if (CheckChangeCondition())
            {
                OnChangeStrategy?.Invoke();
                return true;
            }
            return false;
        }

        protected virtual bool CheckChangeCondition() => _navMeshAgent.remainingDistance <= _stoppingDistance + _distanceEps;
    }
}
