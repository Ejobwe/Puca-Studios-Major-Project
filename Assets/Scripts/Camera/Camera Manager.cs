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
    public void SwapCamera(CinemachineCamera leftCam, CinemachineCamera rightCam, CinemachineCamera frontCam, CinemachineCamera backCam, Vector3 triggerExitDirection)
    {
        if (leftCam != null)
        {
            if (currentCamera == leftCam && triggerExitDirection.x < 0f)
            {
                currentCamera.Priority -= 1;

                rightCam.enabled = true;

                leftCam.enabled = false;

                currentCamera = rightCam;
            }
        }

        if (rightCam != null)
        {
            if (currentCamera == rightCam && triggerExitDirection.x > 0f)
            {
                print("HELLO");
                currentCamera.Priority -= 1;

                leftCam.enabled = true;

                rightCam.enabled = false;

                currentCamera = leftCam;
            }
        }

        if (frontCam != null)
        {
            if (currentCamera == frontCam && triggerExitDirection.z > 0f)
            {
                print("HELLO");
                currentCamera.Priority -= 1;

                backCam.enabled = true;

                frontCam.enabled = false;

                currentCamera = backCam;
            }
        }

        if (backCam != null)
        {
            if (currentCamera == backCam && triggerExitDirection.z < 0f)
            {
                currentCamera.Priority -= 1;

                frontCam.enabled = true;

                backCam.enabled = false;

                currentCamera = frontCam;
            }


        }
    }
}
