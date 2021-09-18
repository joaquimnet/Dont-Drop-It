using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Decisions/Target In Range")]
public class TargetInRange : Decision
{
    public float distance = 10f;

    public override bool Decide(StateController controller)
    {
        return CheckDistance(controller);
    }

    private bool CheckDistance(StateController controller)
    {
        return Vector3.Distance(controller.transform.position, controller.currentTarget.position) < distance;
    }
}
