using Entitas;
using RPG.GameEntity;
using RPG.Asset;

public partial class GameContextExtension {
    public static Entity LoadPlayer (IViewEntityData data) {
        var charcter = CharacterLoader.Load(data);
        charcter.Add<PlayerComp>();
        return charcter;
    }
}