using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeFPController : MonoBehaviour
{
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";

    public float MaxForwardSpeed = 0.05f;
    public float MaxBackwardSpeed = 0.02f;
    public float MaxSidewaysSpeed = 0.02f;
    public float MouseXSensitivity = 10.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Basic translation and rotation of Gnomatic Garden Defender
        Vector3 MoveDirection;

        float strafe = Input.GetAxis(HorzAxis);     //A/D are ranging this value -1 to 1
        float forward = Input.GetAxis(VertAxis);   //W/S are ranging this value -1 to 1
       // print("FixedUpdate, L/R: " + strafe + ", forward " + forward);
        if (forward > 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, forward * MaxForwardSpeed);
            transform.Translate(MoveDirection);
        }
        if (forward < 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, forward * MaxBackwardSpeed);
            transform.Translate(MoveDirection);
        }
        if (forward == 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, 0.0f);
            transform.Translate(MoveDirection);
        }

        if (MouseLook)
        {
            // Mouse movement in the X direction is translated to rotating the gnome. 
            // Another script will use Mouse Y movement to raise & lower the bazooka
            print("MouseX: " + Input.GetAxis("Mouse X"));
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * MouseXSensitivity, 0));
        }
    }
}
