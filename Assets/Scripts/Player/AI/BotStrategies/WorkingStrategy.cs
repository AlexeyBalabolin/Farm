using Infrastructure;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BotAI
{
    public class WorkingStrategy : IBotStrategy
    {
        public event Action OnChangeStrategy;

        private NavMeshAgent _navMeshAgent;
        private BotAnimator _botAnimator;
        private ICoroutineRunner _coroutineRunner;
        private readonly float _workingTime;

        public WorkingStrategy(NavMeshAgent navMeshAgent, BotAnimator botAnimator, float workingTime, Action onEndWorking, ICoroutineRunner coroutineRunner)
        {
            _navMeshAgent = navMeshAgent;
            _botAnimator = botAnimator;
            _workingTime = workingTime;
            _coroutineRunner = coroutineRunner;
            OnChangeStrategy = onEndWorking;
        }

        public void Execute()
        {
            _botAnimator.PlayWorking();
            _botAnimator.StopMoving();
            _navMeshAgent.enabled = false;
            _coroutineRunner.StartCoroutine(Working(_workingTime));
        }

        private IEnumerator Working(float workingTime)
        {
            yield return new WaitForSeconds(workingTime);
            OnChangeStrategy?.Invoke();
        }
    }
}
