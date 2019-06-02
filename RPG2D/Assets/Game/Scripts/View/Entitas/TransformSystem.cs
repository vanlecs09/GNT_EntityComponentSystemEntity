using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace RPG.View
{
    [ViewFeature]
    public class TransformSystem: ReactiveSystem {
        public TransformSystem () {
            monitors += Context<Game>.AllOf<TransformComp>().OnAdded(Execute);
        }

        private void Execute(List<Entity> entities)
        {
            GameObject go = null;
            TransformComp tf = null;
            foreach (var e in entities)
            {
                if (e.Has<ViewComp>()) {
                    go = e.Get<ViewComp>().gameObject;
                    tf = e.Get<TransformComp>();
                    go.transform.position = tf.position;
                    go.transform.localScale = tf.scale;
                    go.transform.rotation = tf.rotation;
                }
            }
        }
    }
}