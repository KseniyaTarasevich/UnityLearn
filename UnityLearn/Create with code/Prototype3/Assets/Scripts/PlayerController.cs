using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animPlayer;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animPlayer.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 1);
        }
    }
}
