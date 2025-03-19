using UnityEngine;
using Unity.Cinemachine;

public class Camera_Trigger : MonoBehaviour
{
    Collider _coll;

   public CameraManager CameraBrain;

    public GameObject FrontCamera;
    public GameObject BackCamera;
    public GameObject LeftCamera;
    public GameObject RightCamera;

    private CinemachineCamera frontCam;
    private CinemachineCamera backCam;
    private CinemachineCamera leftCam;
    private CinemachineCamera rightCam;

    Movement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();

        CameraBrain = GameObject.FindWithTag("CameraManager").GetComponent<CameraManager>();
        _coll = GetComponent<Collider>();

        //CamCheck = transform.parent.transform.parent.GetComponent<Wall_Generator>();
        if (FrontCamera != null)
        {
            frontCam = FrontCamera.GetComponent<CinemachineCamera>();
        }
        if (BackCamera != null)
        {
            backCam = BackCamera.GetComponent<CinemachineCamera>();
        }
        if (LeftCamera != null)
        {
            leftCam = LeftCamera.GetComponent<CinemachineCamera>();
        }
        if (RightCamera != null)
        {
            rightCam = RightCamera.GetComponent<CinemachineCamera>();
        }

    }

    private void Update()
    {
        //if (CamCheck.frontCam != null)
        //{
        //    frontCam = CamCheck.frontCam;
        //}
        //if(CamCheck.backCam != null)
        //{
        //    backCam = CamCheck.backCam;
        //}
        //if(CamCheck.leftCam != null)
        //{
        //    leftCam = CamCheck.leftCam;
        //}
        //if(CamCheck.rightCam != null) 
        //{ 
        //    rightCam = CamCheck.rightCam;
        //}

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Vector3 exitDirection = (other.transform.position - _coll.bounds.center).normalized;
            if (leftCam != null)
            {
                if (exitDirection.x > 0f)
                {

                    RightCamera.SetActive(true);

                    LeftCamera.SetActive(false);

                }
            }
            if (rightCam != null)
            {
                if (exitDirection.x < 0f)
                {

                    LeftCamera.SetActive(true);

                    RightCamera.SetActive(false);

                }
            }
            if (frontCam != null)
            {
                if (exitDirection.z > 0f)
                {
                    BackCamera.SetActive(true);

                    FrontCamera.SetActive(false);
                }
            }
            if (backCam != null)
            {
                if (exitDirection.z < 0f)
                {
                    FrontCamera.SetActive(true);

                    BackCamera.SetActive(false);
                }
            }
            Debug.Log(exitDirection);
            CameraBrain.SwapCamera(leftCam, rightCam, frontCam, backCam, exitDirection);
            
        }
    }
}
