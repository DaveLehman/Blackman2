using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoLauncher : MonoBehaviour
{
    public GameObject projectile;       // the projectile prefab
    public float speed = 20;

    public bool debug = true;

    float loadRate = 0.5f;      // how often a new projectile can be fired
    float timeRemaining;        // how much time before the next shot can happen

    // Start is called before the first frame update
    void Start()
    {
        if(projectile == null)
        {
            Debug.Log("PotatoLauncher started but can't find the projectile prefab");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(Input.GetButton("Fire1") && timeRemaining <= 0)
        {
            timeRemaining = loadRate;
            GetComponent<AudioSource>().Play();
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if(debug)
        {
            Debug.Log("Bang!");
        }
        // create a clone of the projectile at the location and orientation of the script's parent
        GameObject potato = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        // add some force to send the projectile off in it's forward direction
        potato.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
}
