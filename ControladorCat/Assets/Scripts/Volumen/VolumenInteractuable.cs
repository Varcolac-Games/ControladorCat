using cakeslice;
using System.Collections;
using System.Collections.Generic;
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
        outline = GetComponent<Outline>();
        outline.eraseRenderer = true;
    }

    public void isActivateOutliner(bool variable)
    {
        outline.eraseRenderer = !variable;
    }

}
