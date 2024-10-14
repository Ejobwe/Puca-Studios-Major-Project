using UnityEngine;
using Unity.Cinemachine;

public class Camera_Trigger : MonoBehaviour
{
    Collider _coll;

   public CameraManager CameraBrain;

    public CinemachineCamera cameraOnLeft;
    public CinemachineCamera cameraOnRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _coll = GetComponent<Collider>();
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 exitDirection = (other.transform.position - _coll.bounds.center).normalized;
            Debug.Log(exitDirection);
            CameraBrain.SwapCamera(cameraOnLeft, cameraOnRight, exitDirection);
        }
    }
}
