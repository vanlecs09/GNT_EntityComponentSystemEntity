using Entitas;
using UnityEngine;

namespace RPG.Rendering
{
    [Game]
    public class SpriteRendererComp: IComponent {
        public ISpriteRenderer spriteRenderer;
        public ISprite sprite;
        public Color color;

        public void SetSpriteRenderer(ISpriteRenderer newSpriteRenderer) {
            spriteRenderer = newSpriteRenderer;
        }

        public void SetColor (Color newColor) {
            spriteRenderer.Color = newColor;
        }

        public void SetAlpha (float alpha) {
            var color = spriteRenderer.Color;
            color.a = alpha;
            spriteRenderer.Color = color;
        }
    }

    [Game]
    public class AnimatorComp: IComponent {
        public IAnimator animator;

        public void SetAnimator (IAnimator animator) {
            this.animator = animator;
        }
    }

    [Game]
    public class BillboardComp: IComponent {

    }

    [Game]
    public class DropShadowComp: IComponent {

    }
}