using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScale : MonoBehaviour
{
    public OVRGrabbable earth;
    // Update is called once per frame
    void Update()
    {
        if (earth.isGrabbed == true)
        {
            Debug.Log("Yes");
        }
    }
}
