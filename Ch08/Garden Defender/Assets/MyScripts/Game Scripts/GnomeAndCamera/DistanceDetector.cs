using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    // moves the Main Camera attached to the gnomatic defender so that it doesn't pass through the gate objects as the defender
    // goes through the gates. Gradually reduces the distance from the cam to the gnome and the heightof the cam
    public Transform targetTransform;
    public Transform theCamera;
    
    public bool debug = true;

    Vector2 source;     // the gateway
    Vector2 target;     // the gnome
    // Start is called before the first frame update
    void Start()
    {
        if(targetTransform == null)
        {
            Debug.Log("Starting DistanceDetector script on GardenGates, failed to find targetTransform. Attach the Gnome's Parent");
        }
        if (theCamera == null)
        {
            Debug.Log("Starting DistanceDetector script on GardenGates, failed to find theCamera. Attach the ArmGroup");
        }
        source = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // update the target's location
        target = new Vector2(targetTransform.position.x, targetTransform.position.z);
        // get the distance between the target and source
        float dist = Vector3.Distance(source, target);
        
        if (dist < 3.0f && dist > 0.5f)
        {
            
            Vector3 pos = theCamera.transform.localPosition;    // make a variable to hold the current local position of the camera
            pos.z = 3.0f - dist;    // assign the inverse of the distance to the z part of the temporary variable
            theCamera.transform.localPosition = pos;
        }
        
    }
}
