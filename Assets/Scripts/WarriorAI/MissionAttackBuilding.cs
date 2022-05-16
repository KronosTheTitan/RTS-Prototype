using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAttackBuilding : Mission
{
    public TownHall target;
    
    public override void PerformMission()
    {
        _unit.agent.SetDestination(target.transform.position);
    }
}
