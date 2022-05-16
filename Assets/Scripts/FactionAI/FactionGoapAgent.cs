using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionGoapAgent : MonoBehaviour
{
    [SerializeField] private FactionGoal goal;

    public List<GoapTask> tasks;

    [SerializeField] private FactionController faction;

    [SerializeField] private float lastAIUpdate = 0;
    
    private void Update()
    {
        if (tasks.Count == 0)
        {
            GoapTask task = goal.CheckCompleted();
            if (task == null)
            {
                Debug.Log("Task Completed");
                return;
            }
            tasks.Add(task);
        }
        else
        {
            int lastIndex = tasks.Count - 1;
            GoapTask task = tasks[lastIndex].Allowed();
            if (task == null)
            {
                tasks[lastIndex].ExecuteAction();
                tasks.Remove(tasks[lastIndex]);
            }
            else
            {
                tasks.Add(task);
            }
        }
    }
}
