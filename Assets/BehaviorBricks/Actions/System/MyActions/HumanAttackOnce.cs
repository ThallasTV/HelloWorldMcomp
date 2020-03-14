using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/HumanAttackOnce")]
[Help("Clone a 'weapon' and shoots it through the Forward axis with the " +
      "specified velocity.")]
public class HumanAttackOnce : BasePrimitiveAction
{
    // Define the input parameter "weaponPoint".
    [InParam("weaponPoint")]
    public Transform weaponPoint;

    // Define the input parameter "weapon" (the prefab to be cloned).
    [InParam("weapon")]
    public GameObject weapon;

    // Define the input parameter velocity, and provide a default
    // value of 30.0 when used as CONSTANT in the editor.
    [InParam("velocity", DefaultValue = 30f)]
    public float velocity;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        // Instantiate the weapon prefab.
        GameObject newWeapon = GameObject.Instantiate(
                                    weapon, weaponPoint.position,
                                    weaponPoint.rotation * weapon.transform.rotation) as GameObject;
        // Give it a velocity
        if (newWeapon.GetComponent<Rigidbody>() == null)
            // Safeguard test, although the rigid body should be provided by the
            // prefab to set its weight.
            newWeapon.AddComponent<Rigidbody>();

        newWeapon.GetComponent<Rigidbody>().velocity = velocity * weaponPoint.forward;
        // The action is completed. We must inform the execution engine.
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce