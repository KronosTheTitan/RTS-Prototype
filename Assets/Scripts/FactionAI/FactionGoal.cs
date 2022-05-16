using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionGoal : MonoBehaviour
{
    [SerializeField] private GoapTask buildWarrior;
    [SerializeField] private GoapTask buildWorker;

    [SerializeField] private GoapTask AttackEnemy;

    [SerializeField] private FactionController faction;

    [SerializeField] private FactionController enemy;
    
    public GoapTask CheckCompleted()
    {
        if (faction.ownedWorkers.Count<3 || faction.ownedWorkers.Count<faction.ownedUnits.Count*.33f)
        {
            return buildWorker;
        }

        if (faction.ownedUnits.Count < (enemy.ownedUnits.Count * 2) + 1)
        {
            return buildWarrior;
        }

        if (enemy.townHall.health > 0)
        {
            return AttackEnemy;
        }

        return null;
    }
}
