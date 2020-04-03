using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStored : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        if (hasInteracted)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                bool wasPickedUp = Inventory.instance.Add(item);
                if (wasPickedUp)
                    Destroy(gameObject);
                //check if the object is grabbed, if so when the button is pressed
                //add the item to the inventory and destroy the current game object in the scene
            }
        }

    }

}
