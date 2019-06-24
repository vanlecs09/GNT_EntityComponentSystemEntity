using Entitas;
using UnityEngine;
using System;
using Newtonsoft.Json;
using DG.Tweening;

namespace RPG.Rendering
{
    [Game]
    public class SpriteRendererComponent : IComponent
    {
        [JsonIgnore]
        public ISpriteRenderer spriteRenderer;
        [JsonIgnore]
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

        public void ActionDamange()
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(spriteRenderer.SpriteRenderer.DOColor(Color.red, 0.4f))
            .Append(spriteRenderer.SpriteRenderer.DOColor(Color.white, 0.4f));

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