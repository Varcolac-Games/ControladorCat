using UnityEngine;
using UnityEngine.UI;

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
            if (interactable != null)
                RegistreInteractable(interactable);
            
            
        }

        private void OnTriggerExit(Collider other)
        {
            other.TryGetComponent<IInteractable>(out var interactable);
            if (interactable != null)
                UnregistreInteractable(interactable);
        }

        private void RegistreInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
            currentInteractable.isActivateOutliner(true);
        }

        private void UnregistreInteractable(IInteractable interactable)
        {
            currentInteractable.isActivateOutliner(false);
            currentInteractable = null;
        }
    }
}
