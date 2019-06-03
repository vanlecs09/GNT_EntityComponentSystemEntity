using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace RPG.View
{
    // [ViewFeatureAttribute]
    public class TransformSystem: ReactiveSystem {
        public TransformSystem (Contexts contexts) {
            monitors += Context<Game>.AllOf<TransformComp>().OnAdded(Execute).Where(Filter);
        }

        private bool Filter(Entity entity)
        {
            return entity.Has<ViewComp>();
        }

        private void Execute(List<Entity> entities)
        {
            TransformComp tfc = null;
            ITransform tf = null;
            foreach (var e in entities)
            {
                tf = e.Get<ViewComp>().transform;
                tfc = e.Get<TransformComp>();
                tf.Position = tfc.position;
                tf.Rotation = tfc.rotation;
                tf.Scale = tfc.scale;
            }
        }
    }
}