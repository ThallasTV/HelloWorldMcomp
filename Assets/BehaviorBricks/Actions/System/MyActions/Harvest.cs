using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore.Tasks;       // TaskStatus
using Pada1.BBCore;             // Code Attributes
using Pada1.BBCore.Framework;   // BasePrimitiveAction


/// <summary>
/// It is an action to harvest the object
/// </summary>
[Action("MyActions/Harvest")]
[Help("Harvests the game object")]

public class Harvest : BasePrimitiveAction
{
    // Define the input parameter "harvestTime".
    [InParam("harvestTime")]
    public float harvestTime;

    // Define the input parameter "harvestedResources".
    [InParam("harvestedResources")]
    public int harvestedResources;

    public int resources;

    private float currentTime;
    private float elapsedTime;

    /// <summary>Initialization Method of Harvest.</summary>
    /// <remarks>Check starting resources, begin harvesting.</remarks>
    public override TaskStatus OnUpdate()
    {
        Debug.Log("Starting Resources" + resources);

        currentTime = Time.time;
        elapsedTime = Time.time - currentTime;

        while (elapsedTime < harvestTime)
        {
            resources += harvestedResources;
        }

        Debug.Log("Harvested Resources" + resources);

        return TaskStatus.COMPLETED;
    }

    //void Harvesting()
    //{
    //    elapsedTime = Time.time - currentTime;

    //    while (elapsedTime < harvestTime)
    //    {
    //        resources += harvestedResources; ;
    //    }

    //    Debug.Log("Harvested Resources" + resources);
    //}

    /// <summary>Method of Update of Harvest.</summary>
    /// <remarks>Verify the status of the task, if there is no objective fails, if the harvestTime has elapsed it is completed,
    /// the task is running if the harvestTime is still elapsing.</remarks>
    //public override TaskStatus OnUpdate()
    //{
    //    if (elapsedTime == null)
    //        return TaskStatus.FAILED;
    //    if (elapsedTime == harvestTime)
    //        return TaskStatus.COMPLETED;
    //    else if (elapsedTime < harvestTime)
    //        return TaskStatus.RUNNING;
    //}
}