using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Threading;

namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        public Projectile projectilePrefab;
        public Dictionary<InputAction, KeyCode> keyMapping;

        IMovementScheme movementScheme;
        IRotatationScheme rotatationScheme;
        void Start()
        {
            Mesh test = this.myCollider.CreateMesh(true, true);
            keyMapping = KeyMappingFactory.GetNextPlayerInputMappings();
            movementScheme = new SmoothedNormalizedDirectMovement(keyMapping);
            rotatationScheme = new DirectRotationScheme(keyMapping);
        }
        public void KillAndEndRound()
        {
            isDead = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Task.Run(() =>
            {
                Thread.Sleep(3000);
                Debug.Log("Reloading Scene");

                ThreadingCheat.RegisterActionForMainThread(() =>
                {
                    string scene = SceneManager.GetActiveScene().name;
                    //Load it
                    Debug.Log(scene);
                    SceneManager.LoadScene(scene, LoadSceneMode.Single);
                    Debug.Log("Done");
                });
            });


        }
        // Update is called once per frame
        void Update()
        {
            if (keyMapping == null) return;
            movementScheme?.ApplyInput(myBody);
            rotatationScheme?.ApplyInput(myBody);
            if (Input.GetKeyDown(keyMapping[InputAction.Shoot]) && !isDead)
            {
                FireProjectile();
            }
            SetControlScheme();
        }

        private void FireProjectile()
        {
            Projectile p = Projectile.Instantiate(projectilePrefab, myBody.position, Quaternion.identity);
            p.gameObject.SetActive(true);
            p.myBody.velocity = myBody.velocity + rotateVector2(Vector2.right, myBody.rotation) * 5;
            p.myBody.position += rotateVector2(Vector2.right, myBody.rotation) * 1f;
            p.shooter = this;
        }

        public void SetControlScheme()
        {
            var oldscheme = this.movementScheme;
            if (Input.GetKeyDown(KeyCode.Alpha1)) this.movementScheme = new BasicDirectMovement(keyMapping);
            if (Input.GetKeyDown(KeyCode.Alpha2)) this.movementScheme = new NormalizedDirectMovement(keyMapping);
            if (Input.GetKeyDown(KeyCode.Alpha3)) this.movementScheme = new SmoothedNormalizedDirectMovement(keyMapping);
            if (Input.GetKeyDown(KeyCode.Alpha4)) this.movementScheme = new BasicAccelerationMovement(keyMapping);
            if (Input.GetKeyDown(KeyCode.Alpha5)) this.movementScheme = new NormalizedAccelerationMovement(keyMapping);
            if (Input.GetKeyDown(KeyCode.Alpha6)) this.movementScheme = new DampedAccelerationMovement(keyMapping);
            if (this.movementScheme != oldscheme) Debug.Log($"Switched to {this.movementScheme.GetType()}");
        }
        Vector2 rotateVector2(Vector2 vec, float angle)
        {
            float newAngle = Mathf.Atan2(vec.y, vec.x) + angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle));
        }
    }

}

