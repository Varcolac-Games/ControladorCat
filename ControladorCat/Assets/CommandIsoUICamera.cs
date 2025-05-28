using UnityEngine;
using IngameDebugConsole;

public class CommandIsoUICamera : MonoBehaviour
{
    [ConsoleMethod("TestIsoUICamera", "Config Iso & UI Camera")]
    public static void FreeLookCamera()
    {
        GameObject go = GameObject.FindGameObjectWithTag("CamManager");
        CamConController controller = go.GetComponent<CamConController>();
        controller.ChangeCameraController(ControllerCam.IsoControl);

    }
}
