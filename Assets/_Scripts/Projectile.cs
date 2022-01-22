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
            combatant.isDead &= (combatant != shooter && !hasBounced) || (combatant == shooter && hasBounced);
        }

        public void DetermineHit(GameObject hitObj)
        {
            Combatant combatant = hitObj.GetComponent<Combatant>();
            if (combatant != null)
            {
                HitCombatant(combatant);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DetermineHit(collision.gameObject);
        }
    }
}
