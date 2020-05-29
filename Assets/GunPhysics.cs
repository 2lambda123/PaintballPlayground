using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -0.5f, 0);
        this.transform.gameObject.AddComponent<Rigidbody>();
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().mass = 1;
        this.GetComponent<Rigidbody>().drag = 0;
        this.transform.gameObject.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onCollisionEnter(Collision collision)
    {
        this.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
