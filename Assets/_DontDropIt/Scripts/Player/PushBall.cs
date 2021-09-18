using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    public bool enemy = false;
    public AudioClip pushSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball") || (enemy && other.CompareTag("Player")))
        {
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //rb.AddForce(transform.parent.position, ForceMode.Force);
                rb.AddRelativeForce(other.transform.position - transform.parent.position, ForceMode.Force);
                if (pushSound != null && !enemy)
                {
                    SoundManager.Instance.Play(pushSound);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //rb.AddForce(transform.parent.position, ForceMode.Force);
                rb.AddRelativeForce(other.transform.position - transform.parent.position, ForceMode.Force);
                if (pushSound != null && !enemy)
                {
                    SoundManager.Instance.Play(pushSound);
                }
            }
        }
    }
}
