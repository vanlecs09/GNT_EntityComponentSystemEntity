namespace RPG.Rendering
{
    public interface ISpriteRenderer
    {
        UnityEngine.Color Color { get; set; }
        void SetSprite(ISprite sprite);

        UnityEngine.SpriteRenderer SpriteRenderer { get; set;}
    }
}