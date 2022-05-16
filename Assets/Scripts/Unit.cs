using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MapObject
{
    private float _health = 100;

    public FactionController faction;

    public NavMeshAgent agent;

    [SerializeField] protected Mission activeMission;

    [SerializeField] protected MeshRenderer renderer;

    protected virtual void Update()
    {
        activeMission.PerformMission();
    }

    public override void OnLeftClick(Player player)
    {
        if (player.controlledFaction == faction)
        {
            if (!faction.selectedUnit.Contains(this))
            {
                faction.selectedUnit.Add(this);
            }
        }
    }

    public virtual void TakeDamage(Warrior attacker, int damageAmount)
    {
        _health -= damageAmount;
        if (_health < 0)
        {
            Death();
        }
    }
    

    public virtual void Death()
    {
        
    }
}
