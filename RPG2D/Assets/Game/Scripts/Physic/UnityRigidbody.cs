using UnityEngine;

public class UnityRigidbody : MonoBehaviour, IRigidbody
{
    public UnityRigidbody(Rigidbody rigidBody)
    {
        _rigidbody = rigidBody;
    }
    [SerializeField] 
    private Rigidbody _rigidbody;

    public Vector3 Velocity
    {
        get
        {
            return _rigidbody.velocity;
        }
        set
        {
            _rigidbody.velocity = value;
            Debug.Log("veloity " + _rigidbody.velocity);
        }
    }

    public void AddForce(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Force);
    }

    public void AddImpulse(Vector3 force)
    {
        var velocity = _rigidbody.velocity;
//        if (velocity.y < 0f)
//        {
            velocity.y = 0f;
            _rigidbody.velocity = velocity;
        //}
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }

// #if !ENTITAS_DISABLE_VISUAL_DEBUGGING
//     private void OnGUI()
//     {
//         var position = WorldToGuiPosition(transform.position);
//         var rect = new Rect(position.x, position.y, 200f, 30f);

//         GUILayout.BeginArea(rect);
//         GUILayout.BeginHorizontal(GUI.skin.box);
//         GUILayout.Label( _rigidbody.velocity.ToString("F2") + " Velocity");
//         GUILayout.EndHorizontal();
//         GUILayout.FlexibleSpace();
//         GUILayout.EndArea();
//     }
    
//     private static Vector3 WorldToGuiPosition(Vector3 position)
//     {
//         var guiPosition = Camera.main.WorldToScreenPoint(position);
//         guiPosition.y = Screen.height - guiPosition.y;
//         return guiPosition;
//     }
// #endif
}