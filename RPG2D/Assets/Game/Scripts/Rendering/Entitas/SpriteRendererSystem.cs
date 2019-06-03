using System;
using System.Collections.Generic;
using Entitas;

namespace RPG.Rendering
{
    public class SpriteRendererSystem: ReactiveSystem {
        public SpriteRendererSystem (Contexts contexts) {
            monitors += Context<Game>.AllOf<SpriteRendererComp>().OnAdded(OnAddedOrUpdated);
        }

        private void OnAddedOrUpdated(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                var rendererComp = e.Get<SpriteRendererComp>();
                var renderer = rendererComp.spriteRenderer;

                if (rendererComp.sprite != null) {
                    renderer.SetSprite(rendererComp.sprite);
                    rendererComp.sprite = null;
                }

                renderer.Color = rendererComp.color;
            }
        }
    }
}