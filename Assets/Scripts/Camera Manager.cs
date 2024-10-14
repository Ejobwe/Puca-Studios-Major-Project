using UnityEngine;
using Unity.Cinemachine;


public class CameraManager : MonoBehaviour
{
    public CinemachineCamera startCamera;
    public CinemachineCamera currentCamera;

    public CinemachineCamera[] Cameras;

    private void Start()
    {
        currentCamera = startCamera;
    }
    public void SwapCamera(CinemachineCamera cameraFromLeft, CinemachineCamera cameraFromRight, Vector3 triggerExitDirection)
    {
        
        if (currentCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            cameraFromRight.enabled = true;

            cameraFromLeft.enabled = false;

            currentCamera = cameraFromRight;
        }

        if (currentCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            print("HELLO");
            cameraFromLeft.enabled = true;

            cameraFromRight.enabled = false;

            currentCamera = cameraFromLeft;
        }
    }
}
