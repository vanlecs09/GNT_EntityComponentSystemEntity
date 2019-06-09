using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace RPG.View
{
    // [ViewFeatureAttribute]
    public class TransformExclusiveSystem: ReactiveSystem {
        Context _gameContext;

        public TransformExclusiveSystem (Contexts contexts) {
            _gameContext = contexts.GetContext<Game>();
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<PositionComponent>()).OnAdded(PositionChanged).Where(Filter);
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<RotationComponent>()).OnAdded(RotationChanged).Where(Filter);
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<ScaleComponent>()).OnAdded(ScaleChanged).Where(Filter);
        }

        private bool Filter(Entity entity)
        {
            return entity.Has<ViewComponent>();
        }

        private void PositionChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComponent>().transform.Position = e.Get<PositionComponent>().value;
            }
        }

        private void RotationChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComponent>().transform.Rotation = e.Get<RotationComponent>().value;
            }
        }

        private void ScaleChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComponent>().transform.Scale = e.Get<ScaleComponent>().value;
            }
        }
    }
}