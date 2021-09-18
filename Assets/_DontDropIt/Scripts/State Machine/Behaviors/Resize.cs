using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Behavior/Resize")]
public class Resize : Behavior
{
    public Vector3 newSize = new Vector3(1f, 1f, 1f);

    public override void Act(StateController controller)
    {
        ChangeScale(controller);
    }

    private void ChangeScale(StateController controller)
    {
        controller.transform.localScale = newSize;
    }
}
