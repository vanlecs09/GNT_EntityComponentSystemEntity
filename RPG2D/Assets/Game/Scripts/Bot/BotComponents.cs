
using Entitas;

[Game]
public class HumanComponent : IComponent
{
}

[Game]
public class BotComponent : IComponent
{
}

[Game]
public class DummyBotComponent : BotComponent
{
}

[Game]
public class EasyBrainComponent : IComponent
{
}

[Game]
public class NormalBrainComponent: IComponent
{
}


[Game]
public class PlayrBrainComponent : IComponent
{
}
