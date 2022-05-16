using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttackEnemyBase : GoapTask
{
    [SerializeField] private FactionController faction;
    [SerializeField] private FactionController enemy;

    [SerializeField] private GoapTask buildWarrior;
    public override GoapTask Allowed()
    {
        if (faction.ownedWarriors.Count * 2 < enemy.ownedWarriors.Count)
            return buildWarrior;
        return null;
    }

    public override void ExecuteAction()
    {
        foreach (Warrior warrior in faction.ownedWarriors)
        {
            warrior.OrderAttackBuilding(enemy.townHall);
        }
    }
}
