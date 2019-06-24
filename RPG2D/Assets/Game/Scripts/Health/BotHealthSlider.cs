using UnityEngine;

public class BotHealthSlider : ISlider
{
    Transform _barTransform;

    public BotHealthSlider(Transform tranform)
    {
        _barTransform = tranform;
    }
    public float Value
    {
        get
        {
            return _barTransform.localScale.x;
        }
        set
        {
            var oldScale = _barTransform.localScale;
            _barTransform.localScale = new Vector3(value, oldScale.y, oldScale.z);
        }
    }
}