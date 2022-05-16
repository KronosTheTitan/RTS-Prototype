using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public bool canBeCanceled = true;

    public bool allowCounterAttack = false;

    [SerializeField] protected Unit _unit;
    public virtual void StartMission()
    {
        
    }

    public virtual void PerformMission()
    {
        
    }
}
