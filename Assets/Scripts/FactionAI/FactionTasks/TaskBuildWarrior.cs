using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBuildWarrior : GoapTask
{
    [SerializeField] private FactionController faction;

    [SerializeField] private TaskWaitForResources waitForResources;
    
    public override void ExecuteAction()
    {
        Warrior warrior = faction.townHall.BuildWarrior();
        if (warrior == null) return;
        warrior.faction = faction;
    }

    public override GoapTask Allowed()
    {
        if (faction.resources<=Warrior.UnitCost)
        {
            waitForResources.resourceTreshold = Warrior.UnitCost;
            return waitForResources;
        }

        return null;
    }
}
