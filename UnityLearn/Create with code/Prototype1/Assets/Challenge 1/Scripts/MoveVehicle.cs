using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicle : MonoBehaviour
{
    public float speed = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.forward * speed);
    }
}
