using System.Collections.Generic;
using UnityEngine;
namespace KarmaBoomerang
{
    public class DampedAccelerationMovement : NormalizedAccelerationMovement
    {
        float TopSpeed = 10;
        public DampedAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null):base(inputMapping){}
        public override Vector2 GetForce(Vector2 velocity)
        {
            return base.GetForce(velocity) - (velocity*acceleration/TopSpeed);
        }
    }
    
}

