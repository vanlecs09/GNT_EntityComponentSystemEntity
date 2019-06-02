using UnityEngine;
using Entitas;
using System.Collections.Generic;
using System;
using Entitas.Unity;

namespace RPG.View
{
    [ViewFeature]
    public class ViewSystem: ReactiveSystem {
        Context _gameContext;

        public ViewSystem () {
            _gameContext = Contexts.Get<Game>();
            monitors += Context<Game>.AllOf<ViewComp>().OnAdded(OnAdded);
        }

        private void OnAdded (List<Entity> entities) {
            foreach (var e in entities) {
                var go = e.Get<ViewComp>().gameObject = new GameObject();
                go.Link(e, _gameContext);

                if (e.Has<TransformComp>()) {
                    e.Modify<TransformComp>();
                }
            }
        }
    }
}