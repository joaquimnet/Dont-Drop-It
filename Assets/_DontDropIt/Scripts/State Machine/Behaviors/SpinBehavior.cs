using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Behavior/Spin")]
public class SpinBehavior : Behavior
{
    public float speed = 5f;

    public override void Act(StateController controller)
    {
        Spin(controller);
    }

    private void Spin(StateController controller)
    {
        controller.transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f));
    }
}
