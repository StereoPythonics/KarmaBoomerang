using System.Collections;
using UnityEngine;
namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        public Vector2 acceleration;
        public Projectile projectilePrefab;
        IMovementScheme movementScheme = new SmoothedNormalizedDirectMovement();
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            movementScheme.ApplyInput(myBody);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Projectile p = Projectile.Instantiate(projectilePrefab, myBody.position, Quaternion.identity);
                p.myBody.velocity = myBody.velocity + rotateVector2(Vector2.right, myBody.rotation) * 5;
                p.myBody.position += rotateVector2(Vector2.right, myBody.rotation) * 0.5f;
            }
        }
        Vector2 rotateVector2(Vector2 vec, float angle)
        {
            float newAngle = Mathf.Atan2(vec.y, vec.x) + angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle));
        }

    }

}

