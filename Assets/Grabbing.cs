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
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gun;
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) > 0.5f) //When trigger clicked
        {
            gun = FindClosestHoldable();
            gun.transform.position = this.transform.position;
            gun.transform.rotation = this.transform.rotation;
            this.gameObject.tag = "HandHasGun";
            gun.transform.parent = this.transform;
            gun.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gun.GetComponent<Rigidbody>().rotation = Quaternion.identity;

            if (isLeftHand)
            {
                gun.transform.Rotate(0, 0, -90);
                gun.transform.Translate(new Vector3(0.05f, 0, 0.07f));
            }
            else
            {
               gun.transform.Rotate(0, 0, 90);
               gun.transform.Translate(new Vector3(-0.05f, 0, 0.07f));
            }

        }
        else
        {
            this.gameObject.tag = "Untagged";
            gun = FindClosestHoldable();
            gun.transform.parent = null;
        }
    }

    private GameObject FindClosestHoldable()
    {
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("Holdable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in goArray)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest.transform.parent.gameObject;
    }
}
