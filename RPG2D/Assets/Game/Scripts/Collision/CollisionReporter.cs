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
        Debug.Log("on collision enter");
        var thisEntity = gameObject.GetEntityLink().entity;
        var otherEntity = other.gameObject.GetEntityLink().entity;
        InputContext.CreateCollisionInputEntity((Entity)thisEntity, (Entity)otherEntity);
    }
}