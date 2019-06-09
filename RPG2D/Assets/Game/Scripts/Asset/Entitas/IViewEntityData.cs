using Entitas;

namespace RPG.Asset
{
    public interface IViewEntityData {
        string GetId ();
        object GetPrefab ();
        Entity LoadViewEntity ();
    }
}