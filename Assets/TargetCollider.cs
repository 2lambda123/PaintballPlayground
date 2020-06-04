using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{

    public bool color;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        color = false;
        material = Resources.Load("splatter", typeof(Material)) as Material;
    }

   
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            cube.transform.position = contact.point;
            cube.AddComponent<MeshFilter>();
            cube.AddComponent<MeshRenderer>();
            cube.GetComponent<Renderer>().material = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
