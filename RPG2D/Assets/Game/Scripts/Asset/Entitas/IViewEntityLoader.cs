using Entitas;

namespace RPG.Asset
{
    public interface IViewEntityLoader {
        Entity Load (IViewEntityData data);
    }
}