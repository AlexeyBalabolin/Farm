using System;
using UnityEngine.AI;

namespace BotAI
{
    public class IdleStrategy : IBotStrategy
    {
        private BotAnimator _botAnimator;
        private NavMeshAgent _navMeshAgent;
        public event Action OnChangeStrategy;

        public IdleStrategy(NavMeshAgent navMeshAgent, BotAnimator botAnimator)
        {
            _navMeshAgent = navMeshAgent;
            _botAnimator = botAnimator;
        }

        public void Execute()
        {
            _botAnimator.PlayIdle();
            _botAnimator.StopMoving();
            _navMeshAgent.enabled = false;
        }
    }
}
