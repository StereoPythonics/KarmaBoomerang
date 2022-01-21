using System.Collections.Generic;
using UnityEngine;
namespace KarmaBoomerang
{
    public class SmoothedNormalizedDirectMovement:NormalizedDirectMovement
    {
        float smoothingFactor = 5;
        float inverseSmoothingFactor => 1.0f/smoothingFactor;
        public SmoothedNormalizedDirectMovement(Dictionary<InputAction,KeyCode> inputMapping = null ):base(inputMapping){}
        public override void ApplyInput(Rigidbody2D target)
        {
            target.velocity = (target.velocity * (1-inverseSmoothingFactor)) + (inverseSmoothingFactor)*GetDesiredVelocity();
        }
    }
    
}

