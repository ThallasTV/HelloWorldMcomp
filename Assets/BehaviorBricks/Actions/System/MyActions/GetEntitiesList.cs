using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyAction/GetEntitiesList")]
[Help("Gets an entity from a designated list")]

public class GetEntitiesList : BasePrimitiveAction
{
    // Define the input parameter "list" (the list from the spawner prefab).
    [InParam("list")]
    public Spawner entity = GameObject.Find("Spawner").GetComponent<Spawner>();

    // Define the input parameter "entitySpawner" (the spawner prefab).
    [OutParam("entitySpawner")]
    public GameObject entitySpawner;

    public override TaskStatus OnUpdate()
    {   // Sets the list gathered from the GameObject to "entity"
        entity = entitySpawner.GetComponent<Spawner>();

        return TaskStatus.COMPLETED;
    }

    //public override void OnUpdate()
    //{
    //    return TaskStatus.COMPLETED;
    //}
}