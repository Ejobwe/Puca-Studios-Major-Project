using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;


public class CameraManager : MonoBehaviour
{
    public CinemachineCamera startCamera;
    public CinemachineCamera currentCamera;

    public CinemachineCamera[] Cameras;

    private void Start()
    {
        currentCamera = startCamera;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        currentCamera.Priority = 1;
    }
    public void SwapCamera(CinemachineCamera cameraFromLeft, CinemachineCamera cameraFromRight, Vector3 triggerExitDirection)
    {
        
        if (currentCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            currentCamera.Priority -= 1;

            cameraFromRight.enabled = true;

            cameraFromLeft.enabled = false;

            currentCamera = cameraFromRight;
        }

        if (currentCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            print("HELLO");
            currentCamera.Priority -= 1;

            cameraFromLeft.enabled = true;

            cameraFromRight.enabled = false;

            currentCamera = cameraFromLeft;
        }
    }
}
