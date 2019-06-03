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
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<PositionComp>()).OnAdded(PositionChanged).Where(Filter);
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<RotationComp>()).OnAdded(RotationChanged).Where(Filter);
            monitors += _gameContext.GetGroup(Matcher<Game>.AllOf<ScaleComp>()).OnAdded(ScaleChanged).Where(Filter);
        }

        private bool Filter(Entity entity)
        {
            return entity.Has<ViewComp>();
        }

        private void PositionChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComp>().transform.Position = e.Get<PositionComp>().value;
            }
        }

        private void RotationChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComp>().transform.Rotation = e.Get<RotationComp>().value;
            }
        }

        private void ScaleChanged(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Get<ViewComp>().transform.Scale = e.Get<ScaleComp>().value;
            }
        }
    }
}