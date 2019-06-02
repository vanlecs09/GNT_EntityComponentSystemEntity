using UnityEngine;

namespace RPG.Rendering
{
    public class UnityAnimator : IAnimator
    {
        Animator _animator;

        public UnityAnimator (Animator animator) {
            _animator = animator;
        }

        public void PlayClip(string clip)
        {
            _animator.Play(clip);
        }

        public void SetBool(string param, bool value)
        {
            _animator.SetBool(param, value);
        }

        public void SetFloat(string param, float value)
        {
            _animator.SetFloat(param, value);
        }

        public void SetTrigger(string param)
        {
            _animator.SetTrigger(param);
        }
    }
}