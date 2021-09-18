using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Behavior/Patrol")]
public class PatrolBehavior : Behavior
{
    public override void Act(StateController controller)
    {
        Patrol();
    }

    private void Patrol()
    {
        // TODO: Implement this
        Debug.Log("Patrol Action!");
    }
}
