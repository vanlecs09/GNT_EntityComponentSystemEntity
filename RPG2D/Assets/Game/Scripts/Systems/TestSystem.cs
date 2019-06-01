using Entitas;
using UnityEngine;
using Entitas.VisualDebugging.Unity;


public class TestSystem : IExecuteSystem
{
    public void Execute()
    {
        Debug.Log("test system execute");
    }
}