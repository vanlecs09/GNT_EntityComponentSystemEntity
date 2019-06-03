using UnityEngine;
using Entitas;
using System.Collections.Generic;
using System;
using Entitas.Unity;

namespace RPG.View
{
    // [ViewFeatureAttribute]
    public class ViewSystem: ReactiveSystem, ICleanupSystem {
        Context _gameContext;
        Entity[] _cleanUps;

        public ViewSystem (Contexts contexts) {
            _gameContext = contexts.GetContext<Game>();
            var viewGroup = _gameContext.GetGroup(Matcher<Game>.AllOf<ViewComp>());
            monitors += viewGroup.OnAdded(OnAdded);
            // monitors += viewGroup.OnRemoved(OnRemoved);
        }

        private void OnAdded (List<Entity> entities) {
            foreach (var e in entities) {
                var view = e.Get<ViewComp>();
                if (view.transform == null) {
                    view.transform = GameContextExtension.InstantiateViewTransform();
                }
            }
        }

        private void OnRemoved(List<Entity> entities)
        {
            _cleanUps = new Entity[entities.Count];
            entities.CopyTo(_cleanUps);
        }

        public void Cleanup()
        {
            if (_cleanUps == null) return;

            foreach (var e in _cleanUps)
            {
                e.Destroy();
            }

            _cleanUps = null;
        }
    }
}