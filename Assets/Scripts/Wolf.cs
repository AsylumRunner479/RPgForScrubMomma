using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace RPG.Player
{
    public class Wolf : EnemyAI
    {
        [Space(5), Header("Wolf Stats")]
        public float curStamina;
        public float maxStamina;
        // Start is called before the first frame update

        void Start()
        {
maxStamina = 1000;
curStamina = 0;
        }

        // Update is called once per frame
        public override void Update()
        {
            // A
            
            // B
            if (curStamina >= maxStamina) 
            {
                base.Update();
                curStamina += Time.deltaTime;
                //makes the wolf have tire out over time
            }
            else
            {
                //when the wolf runs out of stamina it falls to sleep and stops moving
                Debug.Log("fall Asleep");
            }
        }
    }
}
