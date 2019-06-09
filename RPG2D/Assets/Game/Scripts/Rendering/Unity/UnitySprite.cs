using UnityEngine;

namespace RPG.Rendering
{
    public class UnitySprite: ISprite {
        public Sprite _sprite;

        public object sprite => (object)_sprite;

        UnitySprite (Sprite sprite) {
            _sprite = sprite;
        }

        public static UnitySprite LoadSingleSprite (string assetPath) {
            Sprite sprite = Resources.Load<Sprite>(assetPath);
            return sprite != null? new UnitySprite(sprite) : null;
        }

        public static UnitySprite LoadFromMultipleSprite (string assetPath, string item) {
            var sprites = Resources.LoadAll<Sprite>(assetPath);
            if (sprites.Length == 0) return null;
            foreach (var s in sprites) {
                if (s.name == item)
                    return new UnitySprite(s);
            }
            return null;
        }
    }
}