using Entitas;

namespace RPG.Asset
{
    public interface IAssetLibrary {
        IViewEntityData GetViewEntityData (string id);
        Entity CreateGameEntity (string id);
    }
}