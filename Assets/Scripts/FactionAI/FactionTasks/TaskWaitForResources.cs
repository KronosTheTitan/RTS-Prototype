using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWaitForResources : GoapTask
{
    public int resourceTreshold = 0;

    [SerializeField] private FactionController faction;

    [SerializeField] private FactionGoapAgent agent;

    [SerializeField] private TaskBuildWorker BuildWorker;

    public override void ExecuteAction()
    {
        if (faction.resources < resourceTreshold)
        {
            agent.tasks.Add(this);
        }
    }

    public override GoapTask Allowed()
    {
        if (faction.ownedWorkers.Count<1 && faction.resources >= Worker.UnitCost)
        {
            return BuildWorker;
        }

        return null;
    }
}
