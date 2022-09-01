using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    Vector3 rotation = new Vector3(0, 0, 2);
    public int speed = 10;

    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(rotation * speed);
    }
}
