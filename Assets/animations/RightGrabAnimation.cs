using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGrabAnimation : MonoBehaviour
{

    private Animator anim;
    private bool isGrabbing;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if( OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.7f && !isGrabbing) 
        {
            anim.SetTrigger("isGrabbingRight");
            isGrabbing = true;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) <= 0.7f && isGrabbing)
        {
            anim.SetTrigger("isGrabbingRight");
            isGrabbing = false;
            
        }
    }
}
