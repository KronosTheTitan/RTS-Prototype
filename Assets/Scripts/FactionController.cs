using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    public List<Unit> selectedUnit;
    public List<Unit> ownedUnits;

    public List<Worker> ownedWorkers;
    public List<Warrior> ownedWarriors;

    public TownHall townHall;

    public int resources = 5;

    [SerializeField] private bool runByPlayer;

    public Material Color;

    void Update()
    {
        if(runByPlayer)
            MouseControls();
    }

    void MouseControls()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("test");
        }
    }
}
