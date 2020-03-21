using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject grabbedObject;
    public float radius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
