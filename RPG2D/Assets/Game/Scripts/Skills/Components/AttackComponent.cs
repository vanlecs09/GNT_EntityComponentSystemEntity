using Entitas;
using System.Collections.Generic;

[Game]
public class AttackComponent : IComponent
{
    public CoolDownComponent coolDown = new CoolDownComponent();
    public float attackSpeed;
    public List<DebuffComponent> debuffs;
    public List<BuffComponent> buffs;
}