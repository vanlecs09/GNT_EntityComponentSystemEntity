using Entitas;
using UnityEngine;
public class CollisionCleanUpSystem : ICleanupSystem
{
    public void Cleanup()
    {
        // Debug.Log("clean up");
        // var entities = Context<Game>.AnyOf<CollisionEnterComponent>().GetEntities();
        // foreach (var e in entities)
        // {
        //     e.GetComponent<CollisionEnterComponent>().listColliEntity.Clear();
        // }
    }
}