using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public List<ResourceNode> resourceNodes;

    public GameObject worker;

    public GameObject warrior;

    public FactionController red;
    public FactionController blue;

    private void Start()
    {
        Instance = this;
    }
}
