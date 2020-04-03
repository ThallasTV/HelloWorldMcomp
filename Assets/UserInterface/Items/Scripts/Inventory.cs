using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found.");
            return;
        }
        instance = this;
    }
    #endregion
    public int slots = 5; //inventory slots
    public List<Item> items = new List<Item>();
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= slots)
            {
                Debug.Log("Your inventory is full.");
                return false;
            }

            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }


}
