using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;
    [SerializeField]
//#if UNITY_EDITOR
//    [Help("This is a dummy state used to manage transitions.", UnityEditor.MessageType.None)]
//#endif
    [Tooltip("This is a dummy state used to manage transitions.")]
    public State remainState;

    [HideInInspector] public int nextWayPoint;

    bool aiActive;
    public Transform currentTarget;
    public GameObject model;

    private void Awake()
    {
        var child = transform.GetChild(0);
        if (child == null) return;
        model = child.gameObject;
    }

    void Start()
    {
        aiActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiActive) return;
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.gizmoColor;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public void AcquireTarget(Transform target)
    {
        if (currentTarget != target) currentTarget = target;
    }
}
