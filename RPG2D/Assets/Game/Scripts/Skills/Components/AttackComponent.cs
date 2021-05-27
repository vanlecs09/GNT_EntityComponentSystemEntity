using Entitas;
using System.Collections.Generic;
public class AttackComponent : IComponent
{
    public float attackSpeed;
    public List<DebuffComponent> debuffs;
    public List<BuffComponent> buffs;
}