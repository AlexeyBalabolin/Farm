using Infrastructure;
using System;
using System.Collections;
using UnityEngine;

namespace BotAI
{
    public class IdleStrategy : IBotStrategy
    {
        private BotAnimator _botAnimator;
        private float _lookAroundTime;
        public event Action OnChangeStrategy;

        private ICoroutineRunner _coroutineRunner;

        public IdleStrategy(BotAnimator botAnimator, float lookAroundTime, Action onLookAround, ICoroutineRunner coroutineRunner)
        {
            _botAnimator = botAnimator;
            _lookAroundTime = lookAroundTime;
            OnChangeStrategy = onLookAround;
            _coroutineRunner = coroutineRunner;
        }

        public void Execute()
        {
            _botAnimator.PlayLookAround();
            _botAnimator.StopMoving();
            _coroutineRunner.StartCoroutine(Looking());
        }

        IEnumerator Looking()
        {
            yield return new WaitForSeconds(_lookAroundTime);
            _botAnimator.StopLookAround();
            OnChangeStrategy?.Invoke();
        }
    }
}
