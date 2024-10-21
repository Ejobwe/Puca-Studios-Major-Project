using UnityEngine;

public class Enviroment_Effects : MonoBehaviour
{

    public bool Slow;
    public bool Slip;

    private float slideX;
    private float slideZ;
    private Vector3 slide;

    Movement player_move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_move = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Slow && other.CompareTag("Player"))
        {
            player_move.playerSpeed = player_move.playerSpeed / 2;
        }
        if (Slip && other.CompareTag("Player"))
        {
            //player_move.playerSpeed = player_move.playerSpeed * 3;
            slideX = player_move.input.x;
            slideZ = player_move.input.z;
            slide = new Vector3 (slideX * 10, 0 , slideZ * 10);
            player_move.rb.velocity = slide;
            player_move.sliding = true;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (Slow && other.CompareTag("Player"))
        {
            player_move.playerSpeed = player_move.playerSpeed * 2;
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
