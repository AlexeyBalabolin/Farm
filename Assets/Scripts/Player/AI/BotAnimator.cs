using UnityEngine;

namespace BotAI
{
    public class BotAnimator : MonoBehaviour
    {
        private const string IdleStateName = "Idle";
        [SerializeField]
        private Animator _animator;

        private static readonly int _speedHash = Animator.StringToHash("Speed");
        private static readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private static readonly int _attackHash = Animator.StringToHash("Attack");
        private static readonly int _lookAroundHash = Animator.StringToHash("LookAround");
        private static readonly int _stopLookAroundHash = Animator.StringToHash("StopLookAround");

        public void Move(float speed)
        {
            _animator.SetBool(_isMovingHash, true);
            _animator.SetFloat(_speedHash, speed);
        }

        public void StopMoving() => _animator.SetBool(_isMovingHash, false);

        public void PlayAttack() => _animator.SetTrigger(_attackHash);

        public void PlayLookAround() => _animator.SetTrigger(_lookAroundHash);

        public void StopLookAround() => _animator.SetTrigger(_stopLookAroundHash);

        public void PlayIdle() => _animator.Play(IdleStateName);

    }
}
