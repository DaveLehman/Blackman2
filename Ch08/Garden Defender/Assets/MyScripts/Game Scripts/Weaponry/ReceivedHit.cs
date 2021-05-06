using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedHit : MonoBehaviour
{
    public bool debug = true;
    public GameObject gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (debug)
            Debug.Log("Rabbit collision -- ReceivedHit()");
        // did we collide with a potato?
        if(collision.transform.tag == "Ammo")
        {
            DestroyBun();
        }
    }

    private void DestroyBun()
    {
        if(debug)
        {
            Debug.Log("Destroying a bunny");
        }
        Destroy(gameObject, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        if (gameManager == null)
        {
            Debug.Log("ReceivedHit script failed to find an object named Game Manager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
