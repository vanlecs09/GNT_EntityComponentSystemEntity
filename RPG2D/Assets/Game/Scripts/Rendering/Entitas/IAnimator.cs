namespace RPG.Rendering
{
    public interface IAnimator {
        void PlayClip (string clip);
        void SetFloat (string param, float value);
        void SetBool (string param, bool value);
        void SetTrigger (string param);
    }
}
