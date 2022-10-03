using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private float zBoundTop = 15;
    private float zBoundBottom = -2;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the player with Arrows
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.forward * speed * verticalInput);
        rb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < zBoundBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundBottom);
        }

        if (transform.position.z > zBoundTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundTop);
        }
    }
}
