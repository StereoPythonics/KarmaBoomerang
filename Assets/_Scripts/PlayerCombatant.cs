using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KarmaBoomerang
{
    public class PlayerCombatant : Combatant
    {
        public float moveAcceleration;
        Vector2 acceleration = new Vector2(0,0)
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                acceleration += new Vector2(0, moveAcceleration));
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                acceleration -= new Vector2(0, moveAcceleration));
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                acceleration += new Vector2(0, -moveAcceleration));
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                acceleration -= new Vector2(0, -moveAcceleration));
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                acceleration += new Vector2(-moveAcceleration, 0));
            }
            if(Input.GetKeyUp(KeyCode.A))
            {
                acceleration -= new Vector2(-moveAcceleration, 0));
            }

            (Input.GetKeyDown(KeyCode.D))
            {
                acceleration += new Vector2(moveAcceleration, 0));
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                acceleration -= new Vector2(moveAcceleration, 0));
            }

            myBody.AddForce(acceleration);
            
        }
    }
}
