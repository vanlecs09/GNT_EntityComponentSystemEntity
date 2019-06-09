using Entitas;
using UnityEngine;
using System;

namespace RPG.Rendering
{
    [Game]
    public class SpriteRendererComponent : IComponent
    {
        // [NonSerialized]
        public ISpriteRenderer spriteRenderer;
        // [NonSerialized]
        public ISprite sprite;
        public Color color;

        public void SetSpriteRenderer(ISpriteRenderer newSpriteRenderer)
        {
            spriteRenderer = newSpriteRenderer;
        }

        public void SetColor(Color newColor)
        {
            spriteRenderer.Color = newColor;
        }

        public void SetAlpha(float alpha)
        {
            var color = spriteRenderer.Color;
            color.a = alpha;
            spriteRenderer.Color = color;
        }
    }

    [Game]
    public class AnimatorComponent : IComponent
    {
        [NonSerialized]
        public IAnimator animator;

        public void SetAnimator(IAnimator animator)
        {
            this.animator = animator;
        }
    }

    [Game]
    public class BillboardComponent : IComponent
    {

    }

    [Game]
    public class DropShadowComponent : IComponent
    {

    }
}