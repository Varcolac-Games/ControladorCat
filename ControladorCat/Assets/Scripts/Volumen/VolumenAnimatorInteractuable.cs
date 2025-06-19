using cakeslice;
using UnityEngine;



public class VolumenAnimatorInteractuable : MonoBehaviour, IInteractable
{
    Animator animator;
    Outline outline;
    public void Action()
    {
        animator.SetTrigger("action");
    }


    private void Start()
    {
        
        animator = GetComponent<Animator>();
        outline = GetComponentInChildren<Outline>();
        outline.eraseRenderer = true;
    }

    public void isActivateOutliner(bool variable)
    {
        outline.eraseRenderer = !variable;
    }

}
