namespace RPG.GameEntity
{
    public interface ICharacterData {
        object CharacterPrefab {get;}
    }

    public interface ICharacterLoader {
        Entitas.Entity Load (ICharacterData data);
    }
}