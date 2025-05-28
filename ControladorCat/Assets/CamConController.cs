using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ControllerCam
{
    FreeLook,
    IsoControl,
    IsoRaycast
}

public class CamConController : MonoBehaviour
{
    public GameObject isoCam;
    public GameObject mainCamera;
    public GameObject followCam;
    public GameObject uiFreeCam;
    public GameObject PlayerArmature;

    public ControllerCam status = ControllerCam.FreeLook;
    

    public void ChangeCameraController(ControllerCam controller)
    {
        switch(controller)
        {
            case ControllerCam.FreeLook:
                ConfigFreeLook();
                break;
            case ControllerCam.IsoControl:
                IsoControl();
                break;
        }
            
    }

    public void ConfigFreeLook()
    {

        mainCamera.GetComponent<Camera>().orthographic = false;
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
        followCam.SetActive(true);
        uiFreeCam.SetActive(true);

    }

    public void IsoControl()
    {

        mainCamera.transform.position = isoCam.transform.position;
        mainCamera.transform.rotation = isoCam.transform.rotation;
        mainCamera.GetComponent<Camera>().orthographic = true;
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;
        followCam.SetActive(false);
        uiFreeCam.SetActive(false);

    }
}
