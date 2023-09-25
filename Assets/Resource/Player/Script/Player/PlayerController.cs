using FPS.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

namespace FPS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        [SerializeField] float animationBlendSpeed = 8.9f;

        [SerializeField] Transform _cameraRoot;
        [SerializeField] Transform _camera;
        [SerializeField] Transform spine;

        [SerializeField] float upLimit = -40f;
        [SerializeField] float downLimit = 70f;
        [SerializeField] float mouseSensitive = 21f;


        private Rigidbody rb;
        private InputManager inputManager;
        private Animator animator;
        private bool _hasAnimator;

        // Pistol Script funtion
        private PistolScript pistolScript;


        private int _Xvelocity, _Yvelocity;
        private int _EquipWeapon;

        private const float crouchSpeed = 1f;
        private const float walkSpeed = 3f;
        private const float runSpeed = 6f;

        private float _xRotation;

        public Vector2 currentVelocity;
        private Vector2 animVelocity;

        public bool canControl = true;
        public bool canControlCamera = true;
        public bool equipWeaon = false;
        private bool buttonPressed = false;

        private int pistolAnimatorLayer, smgAnimatorLayer;
        private float LayerWeightVelocity;

        private bool isCrouching;
        float speed;

        private Vector3 previousPosition;
        public float curSpeed;

        public enum State
        {
            Primary,
            Secondary,
            Melee,
            Unarmed,
        }

        public State state;


        void Start()
        {
            state = State.Secondary;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;

            _hasAnimator = TryGetComponent<Animator>(out animator);
            rb = GetComponent<Rigidbody>();
            inputManager = GetComponent<InputManager>();

            _Xvelocity = Animator.StringToHash("X_Velocity");
            _Yvelocity = Animator.StringToHash("Y_Velocity");
            _EquipWeapon = Animator.StringToHash("Equip_Weapon");

            pistolAnimatorLayer = animator.GetLayerIndex("Pistol_Layer");

            pistolScript = GetComponent<PistolScript>();
        }

        private void FixedUpdate()
        {
            if (!canControl) return;
            Move();
            Crouch();
            EquipWeapon();

        }

        private void LateUpdate()
        {
            CamMovements();
        }

        private void Move()
        {
            if (!_hasAnimator) return;
            MovementState();
            /*if (inputManager.Run && inputManager.Move.y==1)
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }*/

            if (inputManager.Move == Vector2.zero) speed = 0.1f;

            currentVelocity.x = Mathf.Lerp(currentVelocity.x, inputManager.Move.x * speed, animationBlendSpeed * Time.fixedDeltaTime);
            currentVelocity.y = Mathf.Lerp(currentVelocity.y, inputManager.Move.y * speed, animationBlendSpeed * Time.fixedDeltaTime);

            var xVelocityDif = currentVelocity.x - rb.velocity.x;
            var yVelocityDif = currentVelocity.y - rb.velocity.z;
            rb.AddForce(transform.TransformVector(new Vector3(xVelocityDif, 0, yVelocityDif)), ForceMode.VelocityChange);


            animator.SetFloat(_Xvelocity, currentVelocity.x);
            animator.SetFloat(_Yvelocity, currentVelocity.y);


            if (currentSpeed() < 1)
            {
                animator.SetFloat(_Xvelocity, 0);
                animator.SetFloat(_Yvelocity, 0);
            }

        }

        private void MovementState()
        {

            if (inputManager.Run)
            {
                speed = runSpeed;
                return;
            }
            else if (inputManager.Crouch)
            {
                speed = crouchSpeed;
                return;
            }
            speed = walkSpeed;
        }
        private void CamMovements()
        {
            if (!canControlCamera) return;
            if (!_hasAnimator) return;

            var Mouse_X = inputManager.Look.x;
            var Mouse_Y = inputManager.Look.y;


            _xRotation -= Mouse_Y * mouseSensitive * Time.smoothDeltaTime;
            _xRotation = Mathf.Clamp(_xRotation, upLimit, downLimit);

            _camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            if (equipWeaon)
            {
                spine.localRotation = Quaternion.Euler(Mathf.Lerp(spine.localRotation.x + 6, _xRotation, 2f), 0, 0);
            }
            _camera.position = _cameraRoot.position;


            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Mouse_X * mouseSensitive * Time.smoothDeltaTime, 0));
        }

        private void Crouch()
        {
            animator.SetBool("isCrouching", inputManager.Crouch);

            if (!inputManager.Crouch) return;
            speed = crouchSpeed;
        }

        private void EquipWeapon()
        {
            if (inputManager.EquipPrimary)
            {
                state = State.Primary;
            }
            else if (inputManager.EquipSecondary)
            {
                state = State.Secondary;
            }
            Debug.Log(state);
        }
        IEnumerator WaitTilNextPress(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            buttonPressed = false;
        }



        private float currentSpeed()
        {
            Vector3 curMove = transform.position - previousPosition;
            curSpeed = curMove.magnitude / Time.deltaTime;
            previousPosition = transform.position;
            return curSpeed;
        }

        public void setControl(bool canControl)
        {
            this.canControl = canControl;
            GetComponent<Collider>().enabled = canControl;
        }
    }
}
