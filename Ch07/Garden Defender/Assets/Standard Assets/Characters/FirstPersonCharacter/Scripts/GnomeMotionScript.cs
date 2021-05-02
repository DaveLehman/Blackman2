using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeMotionScript : MonoBehaviour
{
    public float forwardSpeed = 2f;
    public float backwardSpeed = 1f;
    public float strafeSpeed = 2f;

    private float fbInput;
    private float lrInput;

    // new for physics
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("f/b: " + fbInput + ", l/r: " + lrInput);
        fbInput = Input.GetAxis("Vertical");// * moveSpeed;
        lrInput = Input.GetAxis("Horizontal");// * rotateSpeed;

        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        if(fbInput > 0)
        {
            fbInput = fbInput * forwardSpeed;
        }
        if(fbInput < 0)
        {
            fbInput = fbInput * backwardSpeed;
        }
        if(lrInput != 0)
        {
            lrInput = lrInput * strafeSpeed;
        }       
    }

    private void FixedUpdate()
    {
        if(fbInput != 0)
        _rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);
        if(lrInput != 0)
        _rb.MovePosition(this.transform.position + this.transform.right * lrInput * Time.fixedDeltaTime);

    }

}
