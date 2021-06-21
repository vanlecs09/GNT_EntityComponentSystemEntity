using Entitas;
using RPG.View;
using UnityEngine;
public class ClickInputSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<PlayerComponent, MoveComponent, DirectionComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform.name == "Plane")
                    {
                        var trans = entity.GetComponent<TransformComponent>();
                        hit.point = new Vector3(hit.point.x, 0, hit.point.z);
                        if (entity.HasComponent<MoveTargetPosition>())
                        {
                            entity.GetComponent<MoveTargetPosition>().value = hit.point;
                        }
                        else
                        {
                            entity.AddComponent<MoveTargetPosition>().value = hit.point;
                        }
                    }
                }
            }
        }
    }
}