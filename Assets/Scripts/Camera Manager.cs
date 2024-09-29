using UnityEngine;
using Unity.Cinemachine;


public class CameraManager : MonoBehaviour
{
    public Transform mainCamera;

    public CinemachineCamera[] cameras = new CinemachineCamera[2];

    public CinemachineCamera playerCamera;
    public CinemachineCamera puzzleCamera;
    public Transform pCam;

    private CinemachineCamera currentCamera;
    public CinemachineCamera startCamera;

    public LayerMask puzzleOnly;

    //public bool IsLive;

    // Start is called before the first frame update
    void Start()
    {
        cameras[0] = playerCamera;

        mainCamera = Camera.main.transform;

        currentCamera = startCamera;


    }

    //when called puzzlecam from raycast needs to be input into function
    public void SwitchCamera(CinemachineCamera currentCamera)
    {



        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        cameras[1] = puzzleCamera;
        if (Input.GetKeyDown(KeyCode.K))
        {
             SwitchCamera(puzzleCamera);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             SwitchCamera(playerCamera);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000, layerMask: puzzleOnly))
            {
                if (hit.collider.tag == "Puzzle")
                {
                    puzzleCamera = hit.transform.GetChild(0).GetComponent<CinemachineCamera>();
                    pCam = hit.transform;
                    //SwitchCamera(puzzleCamera);
                }

            }
        }
        if (puzzleCamera == GetComponent<CinemachineBrain>().ActiveVirtualCamera)
        {
            currentCamera = playerCamera;

            foreach (Transform child in pCam.transform)
            {
                child.gameObject.SetActive(true);
            }
            //IsLive = true;
        }
        else if (puzzleCamera != null && puzzleCamera != GetComponent<CinemachineBrain>().ActiveVirtualCamera)
        {
            currentCamera = puzzleCamera;
            foreach (Transform child in pCam.transform)
            {
                if (child.gameObject.tag != "PuzzleCam")
                {


                    //child.gameObject.SetActive(false);

                }
            }
            //IsLive = false;
        }

    }
}
