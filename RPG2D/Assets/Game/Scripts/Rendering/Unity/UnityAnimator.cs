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

        public void Stop(string clip)
        {
            // _animator.GetCurrentAnimatorClipInfo()
        }
    }

    public class UnityDummyAimator : IAnimator
    {
        private void LogError() {
            Debug.LogError("Animator Error");
        }
        public void PlayClip(string clip)
        {
            LogError();
        }

        public void SetBool(string param, bool value)
        {
            LogError();
        }

        public void SetFloat(string param, float value)
        {
            LogError();
        }

        public void SetTrigger(string param)
        {
            LogError();
        }

        public void Stop(string clip)
        {
            throw new System.NotImplementedException();
        }
    }
}