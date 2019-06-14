using UnityEngine;

namespace RPG.Rendering
{
    public class UnitySpriteRenderer : ISpriteRenderer
    {
        SpriteRenderer _spriteRenderer;

        public UnitySpriteRenderer(SpriteRenderer renderer) {
            _spriteRenderer = renderer;
        }

        public Color Color { 
            get => _spriteRenderer.color;
            set {
                _spriteRenderer.color = value;
            }
        }

        public void SetSprite(ISprite sprite)
        {
            throw new System.NotImplementedException();
        }

        public SpriteRenderer SpriteRenderer {
            get => _spriteRenderer;
            set {
                _spriteRenderer = value;
            }
        }
    }
}