using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace RPG.Player
{
    public class Goblin : EnemyAI
    {
        [Space(5), Header("Goblin Stats")]
        public float curStamina;
        public float maxStamina;
        // Start is called before the first frame update

        void Start()
        {
            maxStamina = 500;
            curStamina = 0;
        }

        // Update is called once per frame
        //makes the enemy not die instantly but delays it.
        public override void Die()
        {
            if (curStamina >= maxStamina)
            {
                curStamina += Time.deltaTime;
            }
            else
            {
                
                Destroy(self);
            }
        }
    }
}
