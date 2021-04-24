using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeTest : MonoBehaviour
{
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxForwardSpeed = 0.05f;
    public float MaxBackwardSpeed = 0.02f;
    public float MaxSidewaysSpeed = 0.02f;
    public float MouseXSensitivity = 10.0f;
    private Rigidbody ThisBody = null;

    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        if(ThisBody == null)
        {
            print("Failed to find a RigidBody on the Gnome assembly");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 MoveDirection; 
        // called before physics is updated
        float strafe = Input.GetAxis(HorzAxis);     //A/D are ranging this value -1 to 1
        float forward = Input.GetAxis(VertAxis);   //W/S are ranging this value -1 to 1
        print("FixedUpdate, L/R: " + strafe + ", forward " + forward);
        if(forward > 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, forward * MaxForwardSpeed);
            transform.Translate(MoveDirection);
        }
        if (forward < 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, forward * MaxBackwardSpeed);
            transform.Translate(MoveDirection);
        }
        if(forward == 0)
        {
            MoveDirection = new Vector3(strafe * MaxSidewaysSpeed, 0.0f, 0.0f);
            transform.Translate(MoveDirection);
        }
        
        /*ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);
        ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
            (Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed)),
            (Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed)));*/
        if(MouseLook)
        {
            // Vector3 MousePosWorld = GnomeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            //Vector3 MousePosWorld = GnomeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
           // MousePosWorld = new Vector3(0.0f,MousePosWorld.x, 0.0f);
           //Vector3 LookDirection = MousePosWorld - transform.position;

            //transform.localRotation = Quaternion.LookRotation(LookDirection.normalized,Vector3.up);
            //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y")*5, Input.GetAxis("Mouse X")*5, 0));
            transform.Rotate(new Vector3( 0, Input.GetAxis("Mouse X") * MouseXSensitivity, 0));
        }
    }
}
