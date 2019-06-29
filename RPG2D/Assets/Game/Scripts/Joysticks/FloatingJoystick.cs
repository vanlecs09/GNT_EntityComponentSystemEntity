using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        InputContext.CreateJoyStickEntity(new Vector2(0, 0));
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        InputContext.CreateJoyStickEntity(new Vector2(0, 0));
    }

    private void Update()
    {
        if (dirtyFlag)
        {
             InputContext.CreateJoyStickEntity(new Vector2(Horizontal, Vertical));
        }
    }
}