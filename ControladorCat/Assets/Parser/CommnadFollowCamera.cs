using UnityEngine;
using IngameDebugConsole;

public class CommandFreeLookCamera : MonoBehaviour
{
    [ConsoleMethod("TestFreeLookCamera", "Config FreeLook Camera")]
    public static void FreeLookCamera()
    {
        GameObject go = GameObject.FindGameObjectWithTag("CamManager");
        CamConController controller = go.GetComponent<CamConController>();
        controller.ChangeCameraController(ControllerCam.FreeLook);
        
    }
}
