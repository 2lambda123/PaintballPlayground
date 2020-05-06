using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMovement : MonoBehaviour
{
    [SerializeField]
    private bool isLeftHand;
    public bool IsLeftHand
    {
        get { return isLeftHand; }
        set { isLeftHand = value; }
    }
    private Quaternion baseRotation;
    private OVRInput.Controller controller;
    private GameObject playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = this.transform.parent.gameObject;
        baseRotation = transform.rotation;
        controller = IsLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        transform.position = playerCam.transform.position + OVRInput.GetLocalControllerPosition(controller);
        transform.rotation = OVRInput.GetLocalControllerRotation(controller);
    }
}
