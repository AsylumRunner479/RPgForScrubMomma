
using UnityEngine;

namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //value Variables
        public float moveSpeed, noise;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20;
        //Struct - Contains Multiple Variables (eg...3 floats)
        private Vector3 _moveDir;
        //Reference Variable
        public PlayerHandler player;
        private CharacterController _charC;

        private void Start()
        {
            _charC = GetComponent<CharacterController>();
            noise = 6f;
        }
        private void Update()
        {
            Move();
            PlayerHandler.curStamina += Time.deltaTime;
        }
        private void Move()
        {
            if (_charC.isGrounded && !PlayerHandler.isDead)
            {
                //set speed
                if (Input.GetButton("Crouch"))
                {
                    noise = 0f;
                    moveSpeed = crouchSpeed;
                    if (PlayerHandler.curStamina <= player.maxStamina && PlayerHandler.curStamina != player.maxStamina)
                    {
                        PlayerHandler.curStamina += Time.deltaTime;
                    }
                }
                else if (Input.GetButton("Sprint") && PlayerHandler.curStamina > 1)
                {
                    noise = 12f;
                    moveSpeed = runSpeed;
                    PlayerHandler.curStamina -= 2*Time.deltaTime;
                }
                
                else
                {
                    noise = 6f;
                    moveSpeed = walkSpeed;
                    if (PlayerHandler.curStamina <= player.maxStamina)
                    {
                        PlayerHandler.curStamina += Time.deltaTime;
                    }
                }
                
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    noise = 18f;
                    _moveDir.y = jumpSpeed;
                }
            }
            if(PlayerHandler.isDead)
            {
                _moveDir = Vector3.zero;
            }
            //Regardless if we are grounded or not
            //apply gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply movement
           
            _charC.Move(_moveDir * Time.deltaTime);
        }

    }

}
