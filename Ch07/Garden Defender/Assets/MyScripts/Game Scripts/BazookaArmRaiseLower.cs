using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaArmRaiseLower : MonoBehaviour
{
    // reuse of old MouseLook script from old unity. Only purpose here is to rotate the bazooka arm

    public float sensitivityY = 15F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    // Update is called once per frame
    void Update()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
    }
}
