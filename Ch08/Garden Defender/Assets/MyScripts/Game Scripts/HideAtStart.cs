using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAtStart : MonoBehaviour
{
    // HideAtStart should be attached to the CornerGarden to hide it when the game starts
    // The Occluders will handle activating the CornerGarden as we go through the garden gates
    public bool debug = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if (debug)
            Debug.Log("CornerGardn's HideAtStart script running");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
