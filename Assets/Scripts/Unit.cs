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
