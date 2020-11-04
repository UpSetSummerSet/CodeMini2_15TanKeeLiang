using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MoveZCube : MonoBehaviour
{
    float speed = 5.0f;
    float zNLimit = -7.3f;
    float zPLimit = 18.47f;
    bool ifTouch = false;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zNLimit && ifTouch == false)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            if (transform.position.z <= zNLimit && ifTouch == false)
            {
                ifTouch = true;
            }
        }
        if (ifTouch == true && transform.position.z < zPLimit)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= zPLimit && ifTouch == true)
            {
                ifTouch = false;
            }
        }
        Debug.Log(ifTouch);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}