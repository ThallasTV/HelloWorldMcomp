using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventory;
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        this.GetComponent<Button>().onClick.AddListener(() => { OpenInventory(); });
    }
    public void OpenInventory()
    {
        open = !open;
        inventory.SetActive(open);
    }
}
