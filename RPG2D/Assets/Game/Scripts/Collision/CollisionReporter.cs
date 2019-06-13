using UnityEngine;
using Entitas.Unity;
using Entitas;

public class CollisionReporter : MonoBehaviour
{
    Entity _entity;
    private void Start()
    {   
       var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
       _entity = entity;
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("on collision enter");
        var thisEntity = gameObject.GetEntityLink().entity;
        var otherEntity = other.gameObject.GetEntityLink().entity;
        InputContext.CreateCollisionInputEntity((Entity)thisEntity, (Entity)otherEntity);
    }
}