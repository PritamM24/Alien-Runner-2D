using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public PlayerController player;//used to store player to access player info so the 
    //camera can follow

    private Vector3 lastplayerposition;//stores the previous info of the player(position)

    private float distancetomove;//difference between the players position current and last frame
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastplayerposition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distancetomove = player.transform.position.x - lastplayerposition.x;

        transform.position = new Vector3(transform.position.x + distancetomove, transform.position.y, transform.position.z);//transform of the current object

        lastplayerposition = player.transform.position;
    }
}
