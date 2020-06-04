using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGrabAnimation : MonoBehaviour
{

    private Animator anim;
    private bool isGrabbing;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        transform.Rotate(0, 0, 90);

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.7f && !isGrabbing)
        {
            anim.SetTrigger("isGrabbingLeft");
            isGrabbing = true;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) <= 0.7f && isGrabbing)
        {
            anim.SetTrigger("isGrabbingLeft");
            isGrabbing = false;

        }
    }
}
