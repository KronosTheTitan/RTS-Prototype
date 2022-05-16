using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MapObject
{
    [SerializeField] private Transform newUnitPoint;

    [SerializeField] private FactionController faction;

    public int health = 100;
    public Worker BuildWorker()
    {
        if (faction.resources >= Worker.UnitCost)
        {
            Worker worker = Instantiate(GameManager.Instance.worker).GetComponent<Worker>();
            worker.transform.position = newUnitPoint.position;
        
            faction.ownedWorkers.Add(worker);
            faction.ownedUnits.Add(worker);

            faction.resources -= Worker.UnitCost;

            return worker;
        }

        return null;
    }

    public Warrior BuildWarrior()
    {
        if (faction.resources >= Warrior.UnitCost)
        {
            Warrior warrior = Instantiate(GameManager.Instance.warrior).GetComponent<Warrior>();
            warrior.transform.position = newUnitPoint.position;
        
            faction.ownedUnits.Add(warrior);
            faction.ownedWarriors.Add(warrior);

            faction.resources -= Warrior.UnitCost;

            Debug.Log("build Worker");

            return warrior;
        }
        return null;
    }
}
