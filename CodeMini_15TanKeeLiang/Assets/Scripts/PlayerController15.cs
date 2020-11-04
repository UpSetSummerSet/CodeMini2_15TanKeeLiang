using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController15 : MonoBehaviour
{
    float zNLimit = -9.0f;
    float zPLimit = 24.42f;
    float xLLimit = -5.61f;
    float xRLimit = -14.385f;
    float jumpForce = 15.0f;
    float speed = -10.0f;
    float gravityModifier = 2.0f;

    int spaceTrack = 0;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Init variables to reference to User Interaction inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Move Player (GameObject) according to user interactions
        transform.Translate(Vector3.left * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);

        if (transform.position.z < zNLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zNLimit);
        }
        else if (transform.position.z > zPLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPLimit);
        }
        if (transform.position.x > xLLimit)
        {
            transform.position = new Vector3(xLLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < xRLimit)
        {
            transform.position = new Vector3(xRLimit, transform.position.y, transform.position.z);
        }

        JumpPlayer();

        Debug.Log(spaceTrack);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingCube"))
        {
            spaceTrack = 0;
        }
        if (collision.gameObject.CompareTag("StartCube"))
        {
            spaceTrack = 0;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            spaceTrack = 0;
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceTrack < 1)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            spaceTrack++;
        }
    }
}
