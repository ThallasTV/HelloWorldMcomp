using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using System;
using UnityEngine;

public class PlayerGrabController : MonoBehaviour
{
    public Interactable focus; //current focus: item or other gameObjects like villagers
    Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if button grabbed
        //Ray ray = cam.ScreenPointToRay(OVRInput.GetLocalControllerPosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 100))
        //{
        //  Interactable interactable = hit.collider.GetComponent<Interactable>();
        //}
    }


}
