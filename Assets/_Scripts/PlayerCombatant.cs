using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        public Vector2 acceleration;
        IMovementScheme movementScheme = new NormalizedDirectMovement(KeyMappingFactory.GetInputMappings(1));
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            movementScheme.ApplyInput(myBody);
        }
    }
    public interface IMovementScheme
    {
        void ApplyInput(Rigidbody2D target);
    }
    public class BasicAccelerationMovement : IMovementScheme
    {
        Dictionary<InputAction,KeyCode> _inputMapping;
        public float acceleration = 100;
        public BasicAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null)
        {
            _inputMapping = inputMapping ?? KeyMappingFactory.GetInputMappings();
        }
        public virtual Vector2 GetForce(Vector2 velocity)
        {
            return _inputMapping.Keys
            .Select(k => Input.GetKey(_inputMapping[k]) ? k.ToVectorDirection()  : Vector2.zero)
            .Aggregate((v0,v1) => v0 + v1);
        }

        public void ApplyInput(Rigidbody2D target)
        {
            target.AddForce(GetForce(target.velocity));
        }
    }
    public class NormalizedAccelerationMovement : BasicAccelerationMovement
    {
        public NormalizedAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null):base(inputMapping){}
        public override Vector2 GetForce(Vector2 velocity)
        {
            return base.GetForce(velocity).normalized * acceleration;
        }
    }

    public class DampedAccelerationMovement : NormalizedAccelerationMovement
    {
        float TopSpeed = 10;
        public DampedAccelerationMovement(Dictionary<InputAction,KeyCode> inputMapping = null):base(inputMapping){}
        public override Vector2 GetForce(Vector2 velocity)
        {
            return base.GetForce(velocity) - (velocity*acceleration/TopSpeed);
        }
    }

    public class BasicDirectMovement : IMovementScheme
    {
        Dictionary<InputAction,KeyCode> _inputMapping;
        public float speed = 10;
        public void ApplyInput(Rigidbody2D target)
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
    public class NormalizedDirectMovement : BasicDirectMovement
    {
        public NormalizedDirectMovement(Dictionary<InputAction,KeyCode> inputMapping = null ):base(inputMapping){}
        public override Vector2 GetDesiredVelocity()
        {
            return base.GetDesiredVelocity().normalized*speed;
        }

    }


    public static class KeyMappingFactory
    {
        public static Dictionary<InputAction,KeyCode>  GetInputMappings(int playerNumber = 0){
            return playerNumber switch
            {
                0 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.W},
                    {InputAction.MoveRight,KeyCode.D},
                    {InputAction.MoveDown,KeyCode.S},
                    {InputAction.MoveLeft,KeyCode.A}
                },
                1 => new Dictionary<InputAction,KeyCode>()
                {
                    {InputAction.MoveUp,KeyCode.UpArrow},
                    {InputAction.MoveRight,KeyCode.RightArrow},
                    {InputAction.MoveDown,KeyCode.DownArrow},
                    {InputAction.MoveLeft,KeyCode.LeftArrow}
                },
            };
        }
    }
    public static class DirectionTranslationExtensions
    {
        public static Vector2 ToVectorDirection(this InputAction inputAction)
        {
            return inputAction switch
            {
                InputAction.MoveUp => Vector2.up,
                InputAction.MoveLeft => Vector2.left,
                InputAction.MoveDown => Vector2.down,
                InputAction.MoveRight => Vector2.right
            };
        }

    }
    public enum InputAction
    {
        MoveUp,
        MoveRight,
        MoveLeft,
        MoveDown
    }
    
}

