using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBuildWorker : GoapTask
{
    [SerializeField] private FactionController faction;

    [SerializeField] private TaskWaitForResources waitForResources;
    public override void ExecuteAction()
    {
        Worker worker = faction.townHall.BuildWorker();
        if(worker == null) return;
        worker.Setup(faction);
    }

    public override GoapTask Allowed()
    {
        if (faction.resources<Worker.UnitCost)
        {
            waitForResources.resourceTreshold = Worker.UnitCost;
            return waitForResources;
        }

        return null;
    }
}
