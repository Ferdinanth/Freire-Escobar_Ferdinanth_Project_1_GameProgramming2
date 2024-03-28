using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public GameObject Player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y,0f);

        if (Player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, 0f);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, 0f);
        }

        playerPosition.z = transform.position.z;
        transform.position =  Vector3.Lerp (transform.position, playerPosition, offsetSmoothing);
    }
}
