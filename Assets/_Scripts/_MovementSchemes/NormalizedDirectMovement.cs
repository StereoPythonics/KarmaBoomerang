
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public class NormalizedDirectMovement : BasicDirectMovement
    {
        public NormalizedDirectMovement(Dictionary<InputAction,KeyCode> inputMapping = null ):base(inputMapping){}
        public override Vector2 GetDesiredVelocity()
        {
            return base.GetDesiredVelocity().normalized*speed;
        }
    }
}