using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public class BasicDirectMovement : IMovementScheme
    {
        Dictionary<InputAction,KeyCode> _inputMapping;
        public float speed = 10;
        public virtual void ApplyInput(Rigidbody2D target)
        {
            target.velocity = GetDesiredVelocity();
        }
        public BasicDirectMovement(Dictionary<InputAction,KeyCode> inputMapping = null)
        {
            _inputMapping = inputMapping ?? KeyMappingFactory.GetInputMappings();
        }
        public virtual Vector2 GetDesiredVelocity()
        {
            return _inputMapping.Keys
            .Select(k => Input.GetKey(_inputMapping[k]) ? k.ToVectorDirection()  : Vector2.zero)
            .Aggregate((v0,v1) => v0 + v1)*speed;
        }
    }
    
}

