using Entitas;

public class InitializeLevelSystem : IInitializeSystem
{
    EntitySaveLoader _entitySaveLoader;
    public void Initialize()
    {
        if (_entitySaveLoader == null)
        {
            _entitySaveLoader = new EntitySaveLoader(new TemplateLoader());
        }
        _entitySaveLoader.ReLoadTemplets();
        _entitySaveLoader.LoadEntitiesFromSaveFile(Contexts.sharedInstance, "van_test_1");
    }
}