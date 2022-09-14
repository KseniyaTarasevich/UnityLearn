using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;
    public string inputID;

    public Camera driver1;
    public Camera above1;

    public Camera driver2;
    public Camera above2;

    void Start()
    {
        driver1.enabled = false;
        above1.enabled = true;

        driver2.enabled = false;
        above2.enabled = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

        if (inputID == "1" && Input.GetKeyDown(KeyCode.Q) && driver1.enabled == false)
        {
            driver1.enabled = true;
            above1.enabled = false;
        }

        else if (inputID == "1" && Input.GetKeyDown(KeyCode.Q) && driver1.enabled == true)
        {
            driver1.enabled = false;
            above1.enabled = true; ;
        }

        if (inputID == "2" && Input.GetKeyDown(KeyCode.Z) && driver2.enabled == false)
        {
            driver2.enabled = true;
            above2.enabled = false;
        }

        else if (inputID == "2" && Input.GetKeyDown(KeyCode.Z) && driver2.enabled == true)
        {
            driver2.enabled = false;
            above2.enabled = true; ;
        }
    }
}
