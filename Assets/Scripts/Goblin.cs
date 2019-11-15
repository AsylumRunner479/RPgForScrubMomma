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
        public override void Update()
        {
            // A

            // B
            if (curStamina >= 0)
            {
                base.Update();
                curStamina -= Time.deltaTime;
                //makes the goblin tire out over time
            }
            else
            {
                //fallAsleep when you run out of stamina and stop moving
                Debug.Log("fall Asleep");
            }
        }
    }
}
