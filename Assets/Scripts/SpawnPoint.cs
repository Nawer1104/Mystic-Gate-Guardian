using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float delayTime;

    public GameObject soldierPrefab;

    private void Start()
    {
        delayTime = GameManager.Instance.spawnTime;
    }

    private void Update()
    {
        if (delayTime < 0f)
        {
            GameObject soldier = Instantiate(soldierPrefab, transform.position, Quaternion.identity) as GameObject;

            delayTime = GameManager.Instance.spawnTime;
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
    }
}
