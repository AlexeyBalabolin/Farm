using UnityEngine;

namespace BotAI
{
    public class BotAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private static readonly int _speedHash = Animator.StringToHash("Speed");
        private static readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private static readonly int _idleHash = Animator.StringToHash("Idle");
        private static readonly int _workingHash = Animator.StringToHash("Work");

        public void Move(float speed)
        {
            _animator.SetBool(_isMovingHash, true);
            _animator.SetFloat(_speedHash, speed);
        }

        public void StopMoving() => _animator.SetBool(_isMovingHash, false);

        public void PlayWorking() => _animator.SetTrigger(_workingHash);

        public void PlayIdle (bool isIdle) => _animator.SetBool(_idleHash, isIdle);

    }
}
