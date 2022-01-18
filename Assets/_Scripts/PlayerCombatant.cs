using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                myBody.AddForce(new Vector2(0, moveAcceleration));
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                myBody.AddForce(new Vector2(0, -moveAcceleration));
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                myBody.AddForce(new Vector2(-moveAcceleration, 0));
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                myBody.AddForce(new Vector2(moveAcceleration, 0));
            }

            
        }
    }
}

