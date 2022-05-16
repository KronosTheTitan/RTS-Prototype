using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Unit
{
    private float _lastInteractionTime = 0;

    public static int UnitCost = 5;

    [SerializeField] private GatherFromNode gatherFromNode;
    
    private void Start()
    {
        renderer.material = faction.Color;
        activeMission.StartMission();
    }
    public void Setup(FactionController factionController)
    {
        faction = factionController;
        gatherFromNode.AISetNode();
    }

    public override void Death()
    {
        faction.ownedUnits.Remove(this);
        faction.ownedWorkers.Remove(this);
        Destroy(gameObject);
    }
}
