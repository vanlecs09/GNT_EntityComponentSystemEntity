using UnityEngine;
using Entitas.Unity;
using Entitas;

public class CollisionReporter : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        var thisEntity = gameObject.GetEntityLink().entity;
        var otherEntity = other.gameObject.GetEntityLink().entity;
        InputContext.CreateCollisionInputEntity((Entity)thisEntity, (Entity)otherEntity);
    }

    private void OnTriggerEnter(Collider other)
    {
        var thisEntity = gameObject.GetEntityLink().entity;
        var otherEntity = other.gameObject.GetEntityLink().entity;
        InputContext.CreateCollisionInputEntity((Entity)thisEntity, (Entity)otherEntity);
    }

    private void OnCollisionExit(Collision other) {
        var thisEntity = gameObject.GetEntityLink().entity;
        var otherEntity = other.gameObject.GetEntityLink().entity;
        InputContext.CreateCollisionInputEntity((Entity)thisEntity, (Entity)otherEntity);
    }
}