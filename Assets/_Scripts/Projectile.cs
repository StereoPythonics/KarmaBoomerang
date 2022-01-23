using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KarmaBoomerang
{
    public class Projectile : MonoBehaviour
    {
        public Combatant shooter;
        public Collider2D myCollider;
        public Rigidbody2D myBody;
        public bool hasBounced;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        void HitCombatant(Combatant combatant)
        {
            Debug.Log("Combatant Hit");
            if((combatant != shooter && !hasBounced) || (combatant == shooter && hasBounced)){
                this.gameObject.SetActive(false);
                 (combatant as PlayerCombatant)?.KillAndEndRound();
                 
            }
            
        }

        public void DetermineHit(GameObject hitObj)
        {
            Combatant combatant = hitObj.GetComponent<Combatant>();
            if (combatant != null)
            {
                HitCombatant(combatant);
            }
            this.hasBounced |= hitObj.name.Contains("Wall");
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            DetermineHit(collision.gameObject);
        }
    }
}
