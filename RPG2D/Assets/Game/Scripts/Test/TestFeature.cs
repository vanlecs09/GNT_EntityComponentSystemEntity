using Entitas;
using Entitas.VisualDebugging.Unity;

public class TestFeature :
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public TestFeature(Contexts contexts) : base("TestScene")
    {
        Add(new System1())
        .Add(new System2())
        .Add(new System3());
        // Add(new System4());
    }
}

[Test]
public class ComponentA : IComponent
{
    public int x;
    public float y;
}

[Test]
public class ComponentB : IComponent
{

    public int x;
    public float y;
}
[Test]
public class ComponentC : IComponent
{

    public int x;
    public float y;
}
[Test]
public class ComponentD : IComponent
{

    public int x;
    public float y;
}
[Test]
public class ComponentE : IComponent
{

    public int x;
    public float y;
}

[Test]
public class ComponentF : IComponent
{

    public int x;
    public float y;
}
[Test]
public class ComponentG : IComponent
{

    public int x;
    public float y;
}
[Test]
public class ComponentH : IComponent
{

}
[Test]
public class ComponentI : IComponent
{

}

[Test]
public class ComponentJ : IComponent
{

}
[Test]
public class ComponentK : IComponent
{

}
[Test]
public class ComponentL : IComponent
{

}

[Test]
public class ComponentM : IComponent
{

}
[Test]
public class ComponentN : IComponent
{

}

public class System1 : IExecuteSystem
{
    public System1()
    {
    }
    public void Execute()
    {
        var entities = Context<Test>.AllOf<ComponentA, ComponentB, ComponentC>().GetEntities();
        foreach (var e in entities)
        {
            var a = e.Modify<ComponentA>();
            var b = e.Modify<ComponentB>();
            var c = e.Modify<ComponentC>();
            a.x += 1;
            b.x += 2;
            c.x += 1;
        }
    }
}


public class System2 : IExecuteSystem
{
    public System2()
    {
    }
    public void Execute()
    {
        var entities = Context<Test>.AllOf<ComponentD, ComponentE, ComponentF>().GetEntities();
        foreach (var e in entities)
        {
            var a = e.Modify<ComponentD>();
            var b = e.Modify<ComponentE>();
            var c = e.Modify<ComponentF>();
            a.x += 1;
            b.x += 2;
            c.x += 1;
        }
    }
}


public class System3 : IExecuteSystem
{
    public System3()
    {
    }
    public void Execute()
    {
        var entities = Context<Test>.AllOf<ComponentA, ComponentC, ComponentF>().GetEntities();
        foreach (var e in entities)
        {
            var a = e.Modify<ComponentA>();
            var b = e.Modify<ComponentC>();
            var c = e.Modify<ComponentF>();
            a.x += 1;
            b.x += 2;
            c.x += 1;
        }
    }
}


public class System4 : IExecuteSystem
{
    public System4()
    {
    }
    public void Execute()
    {
        var entities = Context<Test>.AllOf<ComponentA, ComponentC, ComponentB, ComponentD, ComponentE, ComponentF>().GetEntities();
        foreach (var e in entities)
        {
            var a = e.Modify<ComponentA>();
            var b = e.Modify<ComponentB>();
            var c = e.Modify<ComponentC>();
            var d = e.Modify<ComponentD>();
            var e1 = e.Modify<ComponentE>();
            var f = e.Modify<ComponentF>();
            a.x += 1;
            b.x += 2;
            c.x += 1;
            d.x += 1;
            e1.x += 1;
            f.x += 1;
        }
    }
}