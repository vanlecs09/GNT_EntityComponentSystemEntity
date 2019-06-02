using UnityEngine;
using Entitas;

namespace RPG.View
{
    [ViewFeature]
    public class TestViewSystem : IInitializeSystem
    {
        public void Initialize()
        {
            var e = Contexts.Get<Game>().CreateEntity();
            e.Add<ViewComp>();
            e.Add<TransformComp>();
        }
    }
}