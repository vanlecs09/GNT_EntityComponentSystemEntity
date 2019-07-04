using RPG.Rendering;
using RPG.View;
using UnityEngine;

public class UnityComponentsCache : MonoBehaviour
{
    public Animator animator = null;
    public SpriteRenderer spriteRenderer = null;

    public Rigidbody rigidBody = null;

    public bool HasSpriteRenderer()
    {
        return spriteRenderer != null;
    }

    public bool HasRigidBody()
    {
        return rigidBody != null;
    }

    public ISpriteRenderer GetSpriteRender()
    {
        if (spriteRenderer != null)
        {
            return new UnitySpriteRenderer(spriteRenderer);
        }
        return null;
    }

    public IRigidbody GetRigidbody()
    {
        if (rigidBody != null)
        {
            return new UnityRigidbody(rigidBody);
        }
        return null;
    }

    public bool HasAnimator()
    {
        return animator != null;
    }

    public IAnimator GetAnimator()
    {
        if(animator != null)
        {
            return new UnityAnimator(animator);
        }

        return null;
    }


}