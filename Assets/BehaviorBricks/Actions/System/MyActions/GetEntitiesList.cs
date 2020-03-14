using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEntitiesList : MonoBehaviour
{
    public Spawner entity;

    public GameObject entitySpawner;

    void Awake()
    {
        entity = gameObject.GetComponent<Spawner>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
