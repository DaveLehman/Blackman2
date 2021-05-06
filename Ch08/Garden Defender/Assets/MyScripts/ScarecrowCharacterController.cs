using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowCharacterController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator)
        {
            float v = Input.GetAxis("Vertical");
            animator.SetFloat("Input V", v);
            print(v);
        }
    }
}
