using Entitas;
using RPG.Asset;
using UnityEngine;

public class TestSceneInitSystem : IInitializeSystem
{
    private readonly Context _gameContext;
    private readonly IAssetLibrary _assetLibrary;
    
    public TestSceneInitSystem (Contexts contexts, IAssetLibrary assetLibrary) {
        _gameContext = contexts.GetContext<Game>();
        _assetLibrary = assetLibrary;
    }

    public void Initialize()
    {
        var entity = _assetLibrary.CreateGameEntity("player");
        if (entity != null) Debug.Log("Create player");
    }
}