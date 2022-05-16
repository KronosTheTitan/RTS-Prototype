using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapTask : MonoBehaviour
{
    public virtual void ExecuteAction()
    {
        
    }
    public virtual GoapTask Allowed()
    {
        return null;
    }
}
