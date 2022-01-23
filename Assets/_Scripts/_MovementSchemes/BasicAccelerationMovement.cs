
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public class BasicAccelerationMovement : IMovementScheme
    {
        Dictionary<InputAction,KeyCode> _inputMapping;
        public float acceleration = 50;
        public BasicAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null)
        {
            _inputMapping = inputMapping ?? KeyMappingFactory.GetInputMappings();
        }
        public virtual Vector2 GetForce(Vector2 velocity)
        {
            return _inputMapping.Keys
            .Select(k => Input.GetKey(_inputMapping[k]) ? k.ToVectorDirection()  : Vector2.zero)
            .Aggregate((v0,v1) => v0 + v1)*acceleration;
        }

        public virtual void ApplyInput(Rigidbody2D target)
        {
            target.AddForce(GetForce(target.velocity));
        }
    }
}