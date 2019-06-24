using RPG.Rendering;
using RPG.View;
using UnityEngine;

public class UnityComponentsCache : MonoBehaviour
{
    public Animator animator = null;
    public SpriteRenderer spriteRenderer = null;

    public IAnimator GetAnimator()
    {
        if (animator == null) return new UnityDummyAimator();
        else return new UnityAnimator(animator);
        // if (animator != null)? new UnityAnimator(animator): new UnityDummyAimator();
    }

    public bool HasSpriteRenderer()
    {
        return spriteRenderer != null;
    }

    public ISpriteRenderer GetSpriteRender()
    {
        if (spriteRenderer != null)
        {
            return new UnitySpriteRenderer(spriteRenderer);
        }
        return null;
    }
}