using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace RPG.View
{
    public class TransformSystem : ReactiveSystem
    {
        public TransformSystem(Contexts contexts)
        {
            monitors += Context<Game>.AllOf<TransformComponent>().OnAdded(Execute).Where(Filter);
        }

        private bool Filter(Entity entity)
        {
            return entity.Has<ViewComponent>();
        }

        private void Execute(List<Entity> entities)
        {
            TransformComponent tfc = null;
            ITransform tf = null;
            foreach (var e in entities)
            {
                if (e.HasComponent<TransformComponent>() && e.HasComponent<ViewComponent>())
                {
                    tf = e.Get<ViewComponent>().transform;
                    tfc = e.Get<TransformComponent>();
                    tf.Position = tfc.position;
                    tf.Rotation = tfc.rotation;
                    tf.Scale = tfc.scale;
                }
            }
        }
    }
}