using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        public Vector2 Move { get; set; }
        public Vector2 Look { get; set; }
        public bool Run { get; set; }
        public bool Jump { get; set; }
        public bool Crouch { get; set; }
        public bool Kick { get; set; }
        public bool EquipPrimary { get; set; }
        public bool EquipSecondary { get; set; }
        public bool EquipMelee { get; set; }
        public bool Shoot { get; set; }
        public bool Knife { get; set; }
        public bool Reload { get; set; }
        public bool Aim { get; set; }
        public bool Flash { get; set; }

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _JumpAction;
        private InputAction _crouchAction;
        private InputAction _lookAction;
        private InputAction _runAction;
        private InputAction _kickAction;
        private InputAction _equipPrimaryAction;
        private InputAction _equipSecondaryAction;
        private InputAction _equipMeleeAction;
        private InputAction _shootAction;
        private InputAction _knifeAction;
        private InputAction _reloadAction;
        private InputAction _aimAction;
        private InputAction _flashLightAction;

        private void Awake()
        {
            _currentMap = playerInput.currentActionMap;
            _moveAction = _currentMap.FindAction("Move");
            _lookAction = _currentMap.FindAction("Look");
            _JumpAction = _currentMap.FindAction("Jump");
            _crouchAction = _currentMap.FindAction("Crouch");
            _runAction = _currentMap.FindAction("Run");
            _kickAction = _currentMap.FindAction("Kick");
            _equipPrimaryAction = _currentMap.FindAction("Primary");
            _equipSecondaryAction = _currentMap.FindAction("Secondary");
            _shootAction = _currentMap.FindAction("Shoot");
            _knifeAction = _currentMap.FindAction("Knife");
            _reloadAction = _currentMap.FindAction("Reload");
            _aimAction = _currentMap.FindAction("Aim");
            _flashLightAction = _currentMap.FindAction("Flashlight");

            _moveAction.performed += onMove;
            _lookAction.performed += onLook;
            _JumpAction.performed += onJump;
            _crouchAction.performed += onCrouch;
            _runAction.performed += onRun;
            _kickAction.performed += onKick;
            _equipPrimaryAction.started += onEquipPrimary;
            _equipSecondaryAction.started += onEquipSecondary;
            _shootAction.started += onShoot;
            _knifeAction.started += onKnife;
            _reloadAction.started += onReload;
            _aimAction.started += onAim;
            _flashLightAction.performed += onFlash;


            _moveAction.canceled += onMove;
            _JumpAction.canceled += onJump;
            _crouchAction.canceled += onCrouch;
            _lookAction.canceled += onLook;
            _runAction.canceled += onRun;
            _kickAction.canceled += onKick;
            _equipPrimaryAction.canceled += onEquipPrimary;
            _equipSecondaryAction.canceled += onEquipSecondary;
            _shootAction.canceled += onShoot;
            _knifeAction.canceled += onKnife;
            _reloadAction.canceled += onReload;
            _aimAction.canceled += onAim;
            _flashLightAction.canceled += onFlash;


        }
        private void onFlash(InputAction.CallbackContext context)
        {
            Flash = context.ReadValueAsButton();
            Debug.Log(Flash);
        }

        private void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }
        private void onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }
        private void onRun(InputAction.CallbackContext context)
        {
            Run = context.ReadValueAsButton();
        }

        private void onKick(InputAction.CallbackContext context)
        {
            Kick = context.ReadValueAsButton();
        }

        private void onJump(InputAction.CallbackContext context)
        {
            Jump = context.ReadValueAsButton();
        }

        private void onEquipPrimary(InputAction.CallbackContext context)
        {
            EquipPrimary = context.ReadValueAsButton();
        }
        private void onEquipSecondary(InputAction.CallbackContext context)
        {
            EquipSecondary = context.ReadValueAsButton();
        }
        private void onShoot(InputAction.CallbackContext context)
        {
            Shoot = context.ReadValueAsButton();
        }
        private void onKnife(InputAction.CallbackContext context)
        {
            Knife = context.ReadValueAsButton();
        }

        private void onReload(InputAction.CallbackContext context)
        {
            Reload = context.ReadValueAsButton();
        }

        private void onCrouch(InputAction.CallbackContext context)
        {
            Crouch = context.ReadValueAsButton();
        }
        
        private void onAim(InputAction.CallbackContext context)
        {
            Aim = context.ReadValueAsButton();
        }


        private void OnEnable()
        {
            _currentMap.Enable();
        }

        private void OnDisable()
        {
            _currentMap.Disable();
        }
    }
}
