using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;

    public Camera driver;
    public Camera above;

    void Start()
    {
        driver.enabled = false;
        above.enabled = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Z) && driver.enabled == false)
        {
            driver.enabled = true;
            above.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.Z) && driver.enabled == true)
        {
            driver.enabled = false;
            above.enabled = true; ;
        }


    }
}

