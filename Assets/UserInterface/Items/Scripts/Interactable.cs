using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public GameObject inventory;

    public OVRGrabbable grabbedObject;
    public float radius = 5f;
    [HideInInspector]
    public bool hasInteracted = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //check if an item is grabbed. change code here
        if (grabbedObject.isGrabbed == true)
        {
            Debug.Log("Interacted");
            hasInteracted = true;
        }
        else
            hasInteracted = false;
    }
    
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        //draw wired sphere for grabbable objects
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
