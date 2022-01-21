using System.Collections;
using UnityEngine;
namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        public Vector2 acceleration;
        IMovementScheme movementScheme = new SmoothedNormalizedDirectMovement();
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            movementScheme.ApplyInput(myBody);
        }
    }
    
}

