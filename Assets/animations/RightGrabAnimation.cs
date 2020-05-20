using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGrabAnimation : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.01f) 
        {
            if (!anim.GetBool("isRightGrabbing"))
            {
                anim.SetBool("isRightGrabbing", true);
            }
        }
        else
        {
            if (anim.GetBool("isRightGrabbing"))
            {
                anim.SetBool("isRightGrabbing", false);
            }
        }
    }
}
