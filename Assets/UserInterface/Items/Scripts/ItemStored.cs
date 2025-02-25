﻿using System.Collections;
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
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
