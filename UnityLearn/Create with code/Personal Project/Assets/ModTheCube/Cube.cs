using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 2f;

        Material material = Renderer.material;

        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        transform.Rotate(25.0f * Time.deltaTime, 0f, 5f * Time.deltaTime);
    }
}
