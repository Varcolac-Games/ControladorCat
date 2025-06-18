using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VolumenAnimatorInteractuable : MonoBehaviour, IInteractable
{
    Animator animator;
    public void Action()
    {
        animator.SetTrigger("action");
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

}
