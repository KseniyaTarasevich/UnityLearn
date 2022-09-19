using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    public GameObject obstaclePrefab;

    private float startDelay = 2f;
    private float repeatRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacles()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
