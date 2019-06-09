using Entitas;



public class Person
{
    public int age;
    public int u;
}

[Game]
public class AssetComponent: IComponent
{
    public string assetName = "";
}

[Game]
public class ExComponent: IComponent
{
    public Person person;
}
