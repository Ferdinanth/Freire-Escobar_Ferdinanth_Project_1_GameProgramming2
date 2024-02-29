using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject myPlayer;
    public float speed = .01f;
    public Rigidbody2D myBody;
    public float bounceMult = 100f;
    Vector3 dirTowards = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        
        Vector3 playerPos = myPlayer.transform.position;
        Vector3 targetPos = Vector3.Lerp(playerPos, this.transform.position, .5f);
        
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed);
    }

    
    void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.name == "player1")
        {
           
            dirTowards = this.transform.position - other.gameObject.transform.position;
            dirTowards = dirTowards.normalized;
            Debug.DrawRay(this.transform.position, dirTowards, Color.cyan, 2f); 
            Debug.Log(dirTowards.magnitude);
            
            myBody.AddForceAtPosition(dirTowards * bounceMult, myPlayer.transform.position);
            Debug.Log("force");
        }

        else if (other.gameObject.name == "enemy")
        {
            Destroy(this.gameObject); 
        }

    }

    public void SetPlayer(GameObject player) 
    {
        myPlayer = player;
    }
}
