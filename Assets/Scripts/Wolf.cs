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
maxStamina = 100;
curStamina = 0;
        }

        // Update is called once per frame
        public override void Update()
        {
            // A
            base.Update();
            // B
            if (curStamina >= maxStamina) 
            {
Debug.Log("Override");
curStamina = 0;
            }
            else
            {
                curStamina += Time.deltaTime;
            }
        }
    }
}
