using UnityEngine;

public class Enviroment_Effects : MonoBehaviour
{

    public bool Slow;
    public bool Slip;

    private float slideX;
    private float slideZ;
    private Vector3 slide;

    PlayerMovement player_move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_move = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Slow && other.CompareTag("Player"))
        {
            player_move.PlayerMoveSpeed = player_move.PlayerMoveSpeed / 2;
        }
        if (Slip && other.CompareTag("Player"))
        {
            //player_move.playerSpeed = player_move.playerSpeed * 3;
            slideX = player_move.Movement.x;
            slideZ = player_move.Movement.z;
            slide = new Vector3 (slideX * 15, 0 , slideZ * 15);
            player_move.Rb.velocity = slide;
            player_move.sliding = true;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (Slow && other.CompareTag("Player"))
        {
            player_move.PlayerMoveSpeed = player_move.PlayerMoveSpeed * 2;
        }
        if (Slip && other.CompareTag("Player"))
        {
            player_move.sliding = false;
            //player_move.playerSpeed = player_move.playerSpeed / 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
