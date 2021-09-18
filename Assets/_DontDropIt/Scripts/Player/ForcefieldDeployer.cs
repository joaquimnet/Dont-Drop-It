using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefieldDeployer : MonoBehaviour
{
    //public float cooldown = 5f;
    public float fadeTime = 5f;
    public float stickTime = 1.5f;
    public GameObject forcefield;
    public AudioClip deploySound;
    public AudioClip fadeSound;

    GameObject currentForcefield;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (currentForcefield != null) return;
            currentForcefield = Instantiate(forcefield, transform);
            currentForcefield.transform.localPosition = Vector3.zero;
            StartCoroutine(DettachForcefield());
            StartCoroutine(DestroyForcefieldAfterTime());
            if (deploySound != null)
            {
                SoundManager.Instance.Play(deploySound);
            }
        }
    }

    void DestroyForcefield()
    {
        Destroy(currentForcefield);
        currentForcefield = null;
        if (deploySound != null)
        {
            SoundManager.Instance.Play(fadeSound);
        }
    }

    IEnumerator DettachForcefield()
    {
        yield return new WaitForSeconds(stickTime);
        currentForcefield.transform.parent = null;
    }
    IEnumerator DestroyForcefieldAfterTime()
    {
        yield return new WaitForSeconds(fadeTime);
        DestroyForcefield();
    }
}
