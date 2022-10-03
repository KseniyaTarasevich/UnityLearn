using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 25f;
    private float leftBound = -15;

    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.LeftShift) && playerControllerScript.isOnGround && !playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
            playerControllerScript.animPlayer.speed = 2;
        }
    }
}
