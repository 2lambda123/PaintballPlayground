using Oculus.Platform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int fireRate;
    private const int FRAME_RATE = 72;

    public int FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    public GameObject projectile;
    private OVRInput.Controller controller;
    public GameObject parentObject;
    private int frameCounter = FRAME_RATE;


    void Start()
    {
       if(fireRate <= 0)
        {
            FireRate = FRAME_RATE;
        }
    }

    // Update is called once per frame
    void Update()
    {
        parentObject = this.transform.parent.gameObject;
        if(parentObject != null)
        {
            controller = this.gameObject.GetComponentInParent<HandMovement>().IsLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller) > 0.5f)
            {
                    frameCounter--;
                if (frameCounter % (FRAME_RATE / fireRate) == 0)
                {
                    if (frameCounter <= 0)
                    {
                        frameCounter = FRAME_RATE;
                    }
                    Transform barrel = null;
                    foreach (Transform item in this.transform)
                    {
                        if (item.tag == "Barrel")
                        {
                            barrel = item;
                        }
                    }
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                    sphere.transform.position = barrel.position;
                    sphere.AddComponent<Rigidbody>();
                    sphere.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
                    sphere.AddComponent<MeshFilter>();
                    sphere.AddComponent<MeshCollider>();
                    sphere.AddComponent<MeshRenderer>();
                    UnityEngine.Object.Destroy(sphere, 5.0f);
                }
            } else
            {
                frameCounter = FRAME_RATE;
            }
        }
    }
}
