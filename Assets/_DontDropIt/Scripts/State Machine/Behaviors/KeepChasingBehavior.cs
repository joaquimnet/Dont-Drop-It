using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Behavior/Keep Chasing")]
public class KeepChasingBehavior : Behavior
{
    public float speed = 5f;

    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        if (controller.currentTarget == null) return;
        controller.transform.LookAt(controller.currentTarget.position);
        controller.transform.rotation.Set(0f, controller.transform.rotation.eulerAngles.y, 0f, 0f);
        controller.transform.eulerAngles = new Vector3(0f, controller.transform.eulerAngles.y, 0f);

        var originalY = controller.transform.position.y;
        var target = Vector3.MoveTowards(controller.transform.position, controller.currentTarget.position, speed * Time.deltaTime);
        target.y = originalY;
        controller.transform.position = target;
    }
}
