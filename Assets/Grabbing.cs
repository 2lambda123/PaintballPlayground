using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    [SerializeField]
    private bool isLeftHand;
    public bool IsLeftHand
    {
        get { return isLeftHand; }
        set { isLeftHand = value; }
    }

    public bool canHold = true;
    public GameObject grip;
    private OVRInput.Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = IsLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) > 0.5f)
        {
            //Grab tag on grip
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
