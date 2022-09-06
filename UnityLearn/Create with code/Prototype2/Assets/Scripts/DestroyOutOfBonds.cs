using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
