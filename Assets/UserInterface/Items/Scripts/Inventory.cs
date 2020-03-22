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
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Add(Item item)
    {
        if (!item.isDefaultItem)
            items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }


}
