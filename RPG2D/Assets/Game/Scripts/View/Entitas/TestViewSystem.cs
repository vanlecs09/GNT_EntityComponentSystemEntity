using UnityEngine;
using Entitas;

namespace RPG.View
{
    // [ViewFeatureAttribute]
    public class TestViewSystem : IInitializeSystem
    {
        Context _gameContext;
        public TestViewSystem (Contexts contexts) {
            _gameContext = contexts.GetContext<Game>();
        }

        public void Initialize()
        {
            var e = _gameContext.CreateEntity();
            e.Add<ViewComponent>();
            e.Add<PositionComponent>().value = new Vector3(2f, 0f, 0f);
        }
    }
}