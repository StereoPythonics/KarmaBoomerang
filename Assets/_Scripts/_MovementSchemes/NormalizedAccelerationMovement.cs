
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public class NormalizedAccelerationMovement : BasicAccelerationMovement
    {
        public NormalizedAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null):base(inputMapping){}
        public override Vector2 GetForce(Vector2 velocity)
        {
            return base.GetForce(velocity).normalized * acceleration;
        }
    }
}