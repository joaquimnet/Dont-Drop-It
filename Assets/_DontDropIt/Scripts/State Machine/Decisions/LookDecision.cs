using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior System/Decisions/Look")]
public class LookDecision : Decision
{
    public float range = 10f;
    public float sphereRadius = 2f;
    public string tag;

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * (range + sphereRadius), Color.green);

        if (Physics.SphereCast(controller.transform.position, sphereRadius, controller.transform.forward, out hit, range) && hit.collider.CompareTag(tag))
        {
            Debug.Log("Looking at player!");
            // TODO: Do mutations here. (Maybe save this player object somewhere)
            controller.AcquireTarget(hit.transform);
            return true;
        } else
        {
            controller.AcquireTarget(null);
            return false;
        }
    }
}
