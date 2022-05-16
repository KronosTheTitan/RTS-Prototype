using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Unit
{
    public static int UnitCost = 10;

    public float combatRange = 7;

    public float attackSpeed = 5;
    public float lastAttack = 0;

    public int damage = 50;

    [SerializeField] private MissionAttackBuilding attackBuilding;

    [SerializeField] private MissionHunt hunt;

    private void Start()
    {
        if(faction == null) Debug.Log("gottem");
        renderer.material = faction.Color;
        activeMission.StartMission();
    }

    public void Attack(Unit target)
    {
        Debug.Log((Time.time < lastAttack + attackSpeed)+" : "+Time.time+" < "+(lastAttack+attackSpeed));
        if (Time.time < lastAttack + attackSpeed) return;
        Debug.Log("attack");
        if(Vector3.Distance(transform.position, target.transform.position) > combatRange) return;
        target.TakeDamage(this,damage);
        lastAttack = Time.time;
    }

    public override void Death()
    {
        faction.ownedUnits.Remove(this);
        faction.ownedWarriors.Remove(this);
        Destroy(gameObject);
    }

    public override void TakeDamage(Warrior attacker, int damageAmount)
    {
        base.TakeDamage(attacker, damageAmount);
        activeMission = hunt;
        hunt.target = attacker;
    }

    public void OrderAttackBuilding(TownHall target)
    {
        attackBuilding.target = target;
        activeMission = attackBuilding;
    }

    public void OrderHunt()
    {
        hunt.StartMission();
        activeMission = hunt;
    }
    
}
