using UnityEngine;

namespace Iso
{ 
    /// <summary>
    /// Clase singleton dedicada a conectar InputAction con el proyecto.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// Variable de instancia Singleton de la Clase.
        /// </summary>
        public static InputManager Instance { get; private set; }

        /// <summary>
        /// Referencia de InputActions de la clase.
        /// </summary>
        public InputSystem_Actions inputActions;

        /// <summary>
        /// Vector2 de Input de movimiento.
        /// </summary>
        public Vector2 MoveInput { get; private set; }
        /// Vector2 de Input de vista.
        /// </summary>
        public Vector2 LookInput { get; private set; }
        /// <summary>
        /// Booleano del botón de Interacción del InputManager.
        /// </summary>
        public bool InteractPressed { get; private set; }
        /// <summary>
        /// Booleano del botón de Salto del InputManager.
        /// </summary>
        public bool JumpPressed { get; private set; }
        /// <summary>
        /// Booleano del botón de Sprint del InputManager.
        /// </summary>
        public bool SprintPressed { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            inputActions = new InputSystem_Actions();
            inputActions.Player.Enable();

            // Suscribimos las acciones
            inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

            inputActions.Player.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Look.canceled += _ => LookInput = Vector2.zero;

            inputActions.Player.Interact.started += _ => InteractPressed = true;

            inputActions.Player.Jump.started += _ => JumpPressed = true;

            inputActions.Player.Sprint.started += _ => SprintPressed = true;
        }

        private void LateUpdate()
        {
            InteractPressed = false;
            JumpPressed = false;
            SprintPressed = false;
        }

        /// <summary>
        /// Método para Activación del InputActions del Player.
        /// </summary>
        public void EnableGameplayInput() => inputActions.Player.Enable();
        /// <summary>
        /// Método para Activación del InputActions del Player.
        /// </summary>
        public void DisableGameplayInput() => inputActions.Player.Disable();

        private void OnDisable()
        {
            inputActions.Player.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Player.Disable();
        }
    }
}
