using Entitas;

public partial class GameContextExtension {
    static Context _gameContext;

    public static Context Context {
        get {
            if (_gameContext == null)
                _gameContext = Contexts.Get<Game>();
            return _gameContext;
        }
    }

    public static Entity CreateEntity() {
        return Context.CreateEntity();
    }
}