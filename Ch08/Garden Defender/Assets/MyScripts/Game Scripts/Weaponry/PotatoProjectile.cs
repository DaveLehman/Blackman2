using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoProjectile : MonoBehaviour
{


    public bool debug = true;

    // Start is called before the first frame update
    void Start()
    {
        // give the potato projectile a finite lifetime of 3 seconds
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // we hit something
        Destroy(gameObject, 2f);
    }
}
