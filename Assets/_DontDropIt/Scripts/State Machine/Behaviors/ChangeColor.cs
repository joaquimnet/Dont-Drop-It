using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Behavior/ChangeColor")]
public class ChangeColor : Behavior
{
    [ColorUsageAttribute(true, true)]
    public Color color;
    public string colorName = "_Color";

    public override void Act(StateController controller)
    {
        Colorize(controller);
    }

    private void Colorize(StateController controller)
    {
        if (controller.model == null) return;
        var renderer = controller.model.GetComponent<MeshRenderer>();
        if (renderer == null) return;
        var material = renderer.material;
        if (material == null) return;
        if (material.GetColor(colorName) == color) return;
        material.SetColor(colorName, color);
        Debug.Log("Change Color!");
    }
}
