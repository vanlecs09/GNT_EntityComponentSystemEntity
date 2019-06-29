using UnityEngine.UI;

public class UnitySlider: ISlider
{
    Slider _slider;

    public UnitySlider(Slider slider)
    {
        _slider = slider;
    }

    public float Value
    {
        get {
            return _slider.value;
        }
        set{
            _slider.value = value;
        }
    }
}