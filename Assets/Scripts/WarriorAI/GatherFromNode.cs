using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GatherFromNode : Mission
{
    private ResourceNode _node;

    private int _carryingResources = 0;

    public override void StartMission()
    {
        
    }

    public override void PerformMission()
    {
        if (_node != null)
        {
            if (_carryingResources > 0)
            {
                //Return to town hall and deposit resources
                if (Vector3.Distance(transform.position,  _unit.faction.townHall.transform.position) > 7)
                {
                    if (_unit.agent.destination != _unit.faction.townHall.transform.position)
                    {
                        _unit.agent.SetDestination(_unit.faction.townHall.transform.position);
                    }
                }
                else
                {
                    _unit.faction.resources += _carryingResources;
                    _carryingResources = 0;
                }
            }
            else
            {
                //Go to the selected node to obtain resources
                if (Vector3.Distance(transform.position, _node.transform.position) > 7)
                {
                    if (_unit.agent.destination != _node.transform.position)
                    {
                        _unit.agent.SetDestination(_node.transform.position);
                    }
                }
                else
                {
                    _carryingResources = _node.yield;
                } 
            }
        }
    }

    public void AISetNode()
    {
        float currentYield=0;
        ResourceNode currentBest = null;

        foreach (ResourceNode node in GameManager.Instance.resourceNodes)
        {
            float dist = Vector3.Distance(_unit.transform.position,node.transform.position);
            float yield = node.yield / dist;

            if (currentBest == null || yield > currentYield)
            {
                currentYield = yield;
                currentBest = node;
            }
        }

        _node = currentBest;
    }
}
