using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [Range(2f, 4f)]
    public float spawnIntervalMin = 2f;
    [Range(4f, 10f)]
    public float spawnIntervalMax = 4f;
    public float disabledTime = 10f;
    public Color disabledColor;
    public Color enabledColor;
    public float distanceToDisable = 0.2f;

    public AudioClip disableSound;

    float timeToNextSpawn;
    bool isEnabled = true;
    Transform player;

    private void Start()
    {
        SetColor(enabledColor);
        player = FindObjectOfType<ThirdPersonMovement>()?.transform;
    }

    private void Update()
    {
        if (Time.time > timeToNextSpawn && isEnabled)
        {
            timeToNextSpawn = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
            Instantiate(PickRandomEnemy(), transform.position + Vector3.up, Quaternion.identity);
        }

        if (isEnabled && Vector3.Distance(transform.position, player.position) < distanceToDisable)
        {
            if (disableSound != null)
            {
                SoundManager.Instance.Play(disableSound);
            }
            DisablePad();
            StartCoroutine(TemporaryDisable());
        }
    }

    IEnumerator TemporaryDisable()
    {
        yield return new WaitForSeconds(disabledTime);
        EnablePad();
    }

    void DisablePad()
    {
        ScoreManager.Instance.score += 1000;
        isEnabled = false;
        SetColor(disabledColor);
    }

    void EnablePad()
    {
        isEnabled = true;
        SetColor(enabledColor);
    }

    void SetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.SetColor("_BaseColor", color);
    }


    GameObject PickRandomEnemy()
    {
        return enemyPrefabs[Mathf.FloorToInt(Random.Range(0f, 1f) * enemyPrefabs.Length)];
    }
}
