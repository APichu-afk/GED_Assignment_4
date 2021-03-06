using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public int dmg;
    private bool touched = false;

    void Start()
    {
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 5.0f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetButtonDown("Use"))
        {
            if (playerCam.Find("SpacePart") == null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                transform.parent = playerCam;
                beingCarried = true;
            }
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (beingCarried && other.gameObject.name == "Tree")
        {
            touched = true;
            Debug.Log("Touched " + other.gameObject.name);
        }
    }
}
