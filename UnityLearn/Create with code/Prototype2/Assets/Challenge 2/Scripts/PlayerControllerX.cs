using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float sleepTime = 0f;

    // Update is called once per frame
    void Update()
    {

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && sleepTime <= 0f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            //if (sleepTime <= 1f)
            //{
            //    Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                sleepTime = 0.5f;
            //}

            

        }
        else
            sleepTime -= Time.deltaTime;
    }
}
