using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{

    public bool color;

    // Start is called before the first frame update
    void Start()
    {
        color = false;
    }

   
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject myLine = new GameObject();
            myLine.transform.position = contact.point;
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, contact.point);
            lr.SetPosition(1, contact.point);
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
