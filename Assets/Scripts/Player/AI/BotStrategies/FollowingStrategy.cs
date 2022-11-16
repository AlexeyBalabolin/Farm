using Infrastructure;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BotAI
{
    public class FollowingStrategy : IBotStrategy
    {
        public event Action OnChangeStrategy;

        private NavMeshAgent _navMeshAgent;
        private BotAnimator _botAnimator;
        private Vector3 _target;
        private ICoroutineRunner _coroutineRunner;
        private readonly float _checkTime = 0.5f;
        private readonly float _distanceEps = 0.1f;

        public FollowingStrategy()
        {
                
        }

        public FollowingStrategy(NavMeshAgent navMeshAgent, BotAnimator botAnimator, Vector3 target, Action onCameToPoint, ICoroutineRunner coroutineRunner)
        {
            _navMeshAgent = navMeshAgent;
            _botAnimator = botAnimator;
            _target = target;
            _coroutineRunner = coroutineRunner;
            OnChangeStrategy = onCameToPoint;
        }

        public virtual void Execute()
        {
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_target);
            _coroutineRunner.StartCoroutine(Following());
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

        protected virtual bool CheckChangeCondition() => Vector3.Distance(_navMeshAgent.transform.position, _target) <= _navMeshAgent.stoppingDistance + _distanceEps;
    }
}
