using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class VolumenLigthInteractuable : MonoBehaviour , IInteractable
{
    Outline outline;
    public GameObject desactivateObject;

    public void Action()
    {
        desactivateObject.SetActive(!desactivateObject.activeSelf);
    }


    private void Start()
    {
        outline = GetComponentInChildren<Outline>();
        outline.eraseRenderer = true;
    }

    public void isActivateOutliner(bool variable)
    {
        outline.eraseRenderer = !variable;
    }

}
