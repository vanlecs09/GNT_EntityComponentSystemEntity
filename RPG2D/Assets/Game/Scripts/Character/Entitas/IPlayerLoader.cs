namespace RPG.GameEntity
{
    public interface IPlayerData {
        
    }

    public interface IPlayerLoader {
        Entitas.Entity Load (IPlayerData data);
    }
}