using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace KarmaBoomerang
{
    public class DirectRotationScheme : IRotatationScheme
    {
        Dictionary<InputAction,KeyCode> _inputMapping;
        public float rotationalSpeed = 200;
        public DirectRotationScheme(Dictionary<InputAction,KeyCode> inputMapping = null)
        {
            _inputMapping = inputMapping ?? KeyMappingFactory.GetInputMappings();
        }
        public void ApplyInput(Rigidbody2D target)
        {
            target.angularVelocity = GetDesiredAngularVelocity();
        }
        public virtual float GetDesiredAngularVelocity()
        {
            var returnable = _inputMapping.Keys
            .Select(k => Input.GetKey(_inputMapping[k]) ? k.ToRotation()  : 0)
            .Aggregate((v0,v1) => v0 + v1)*rotationalSpeed;
            
            return returnable;
        }
    }
}