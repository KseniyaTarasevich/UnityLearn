using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        float horizontslInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontslInput * rotationSpeed * Time.deltaTime);
    }
}
