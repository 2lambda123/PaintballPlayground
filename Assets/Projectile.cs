using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    private OVRInput.Controller controller;
    public GameObject parentObject;

    void Start()
    {
       
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
                Transform barrel = null;
                foreach (Transform item in this.transform)
                {
                    if(item.tag == "Barrel")
                    {
                        barrel = item;
                    }
                }

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                sphere.transform.position = barrel.position;
                sphere.AddComponent<Rigidbody>();
                sphere.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                sphere.AddComponent<MeshFilter>();
                sphere.AddComponent<MeshCollider>();
                sphere.AddComponent<MeshRenderer>();
            }
        }
    }
}
