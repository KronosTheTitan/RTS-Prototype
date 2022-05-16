using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissionHunt : Mission
{
    private FactionController enemy;

    public Unit target;
    private float priority = 0;

    private float swapTargetPriorityMargin;

    private Warrior self;

    public override void StartMission()
    {
        if (GameManager.Instance.blue == _unit.faction)
            enemy = GameManager.Instance.red;
        else
            enemy = GameManager.Instance.blue;
        if (_unit is Warrior)
        {
            self = (Warrior)_unit;
        }
        else
        {
            Debug.LogError("MissionHunt attached to inappropriate unit type");
        }
    }

    public override void PerformMission()
    {
        if (target == null)
        {
            List<Unit> potentialTargets = new List<Unit>();
            foreach (Unit unit in enemy.ownedUnits)
            {
                if(Vector3.Distance(_unit.transform.position,unit.transform.position)<75)
                    potentialTargets.Add(unit);
            }
        
            if(potentialTargets.Count==0) return;

            Unit bestOption = null;
            float bestPriority = 0;
        
            foreach (Unit unit in potentialTargets)
            {
                float prio = 0;
                if (unit is Worker) prio += 10;
                prio += 75 - Vector3.Distance(_unit.transform.position, unit.transform.position);
                if (bestOption == null || bestPriority < prio)
                {
                    bestOption = unit;
                    bestPriority = prio;
                }
            }
            
            priority = bestPriority;
            target = bestOption;
        }

        self.agent.SetDestination(target.transform.position);
        self.agent.stoppingDistance = self.combatRange;
        self.Attack(target);
    }
}
