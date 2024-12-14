
using BarthaSzabolcs.IsometricAiming;
using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Spawn;
    private IsometricAiming isometricAiming;
    private Vector3 Mpos;

    private void Start()
    {
        isometricAiming = Player.GetComponent<IsometricAiming>();
        Mpos = isometricAiming.Pos;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(Mpos);
            Instantiate(Spawn, isometricAiming.Pos, Quaternion.identity);
        }
    }
}
