using UnityEngine;
using UnityEngine.UI;

namespace Iso
{
    public class WorldAction : MonoBehaviour
    {
        public IActionPerformer currentInteractable;
        public GameObject currentObject;
        public ActionType actionType;
        
        // Update is called once per frame
        void Update()
        {
            if (InputManager.Instance.InteractPressed)
            {
                Push();
            }

            if(InputManager.Instance.JumpPressed)
            {
                Hide();
            }
        }

        public void Push()
        {
            if (currentInteractable != null)
            {
                actionType = ActionType.PushOrScratch;
                currentInteractable?.PerformAction(actionType, gameObject, currentObject);
                Debug.Log("Action");
            }
        }

        public void Hide()
        {
            if (currentInteractable != null)
            {
                actionType = ActionType.Hide;
                currentInteractable?.PerformAction(actionType, gameObject, currentObject);
                Debug.Log("Hide");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<IActionPerformer>(out var interactable);
            if (interactable != null)
            {
                currentObject = other.gameObject;
                RegistreInteractable(interactable);
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject == currentObject)
                currentObject = null;
            other.TryGetComponent<IActionPerformer>(out var interactable);
            if (interactable != null)
                UnregistreInteractable(interactable);
        }

        private void RegistreInteractable(IActionPerformer interactable)
        {
            currentInteractable = interactable;
            //currentInteractable.isActivateOutliner(true);
            
        }

        private void UnregistreInteractable(IActionPerformer interactable)
        {
            //currentInteractable.isActivateOutliner(false);
            currentInteractable = null;
            currentObject = null;
        }
    }
}
