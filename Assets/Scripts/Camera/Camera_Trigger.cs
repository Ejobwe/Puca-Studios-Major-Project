using UnityEngine;
using Unity.Cinemachine;

public class Camera_Trigger : MonoBehaviour
{
    Collider _coll;

   public CameraManager CameraBrain;

    bool transition;

    Wall_Generator CamCheck;

    public CinemachineCamera frontCam;
    public CinemachineCamera backCam;
    public CinemachineCamera leftCam;
    public CinemachineCamera rightCam;

    Movement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();

        CameraBrain = GameObject.FindWithTag("CameraManager").GetComponent<CameraManager>();
        _coll = GetComponent<Collider>();

        CamCheck = transform.parent.transform.parent.GetComponent<Wall_Generator>();

        
    }

    private void Update()
    {
        if (CamCheck.frontCam != null)
        {
            frontCam = CamCheck.frontCam;
        }
        if(CamCheck.backCam != null)
        {
            backCam = CamCheck.backCam;
        }
        if(CamCheck.leftCam != null)
        {
            leftCam = CamCheck.leftCam;
        }
        if(CamCheck.rightCam != null) 
        { 
            rightCam = CamCheck.rightCam;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Vector3 exitDirection = (other.transform.position - _coll.bounds.center).normalized;
            Debug.Log(exitDirection);
            CameraBrain.SwapCamera(leftCam, rightCam, frontCam, backCam, exitDirection);
            transition = false;
        }
    }
}
