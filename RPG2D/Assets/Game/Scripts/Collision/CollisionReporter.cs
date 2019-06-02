using UnityEngine;
using Entitas.Unity;
using Entitas;
public class CollisionReporter : MonoBehaviour
{
    Entity _entity;
    private void Start()
    {   
        // just for testing
       var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
       _entity = entity;
    }
    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log(other.gameObject.tag);
        InputContext.CreateCollisionInputEntity(other.gameObject.tag);
    }
}