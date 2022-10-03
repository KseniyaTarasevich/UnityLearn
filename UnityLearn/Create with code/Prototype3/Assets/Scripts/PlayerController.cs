using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Animator animPlayer;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float jumpForce;
    private float doubleJumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public float score = 0;

    public Transform startingPoint;
    public float lerpSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        gameOver = true;
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startingPoint.position;

        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // isOnGround = false;
            animPlayer.SetTrigger("Jump_trig");
            dirtParticle.Play();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            isOnGround = false;
            animPlayer.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1f);
        }

        if (!gameOver)
        {
            score += Time.deltaTime;
            Debug.Log("Score: " + Mathf.FloorToInt(score));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                score += Time.deltaTime * 2;
                Debug.Log("Score: " + Mathf.FloorToInt(score));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
}


