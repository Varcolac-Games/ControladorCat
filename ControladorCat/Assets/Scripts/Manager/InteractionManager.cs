using UnityEngine;

namespace Iso
{
    public class InteractionManager : MonoBehaviour
    {
        IInteractable currentInteractable;

        // Update is called once per frame
        void Update()
        {
            if (InputManager.Instance.InteractPressed)
            {
                currentInteractable?.Action();
            }
    }

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<IInteractable>(out var interactable);
            RegistreInteractable(interactable);
        }

        private void OnTriggerExit(Collider other)
        {
            other.TryGetComponent<IInteractable>(out var interactable);
            UnregistreInteractable(interactable);
        }

        private void RegistreInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
        }

        private void UnregistreInteractable(IInteractable interactable)
        {
            currentInteractable = null;
        }
    }
}
