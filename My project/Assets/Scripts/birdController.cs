using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 1f;
    public SpriteRenderer mySprite;
    public bool dead = false;
    public float myHealth = 1000;
    Rigidbody2D rb;

    Vector3 previousPos;
    Vector3 myDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Dir()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Hortizontal");
        myDir = new Vector3 (y, x, 0);
        Debug.Log(myDir);
        return myDir;
    }
    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        transform.Translate(new Vector3(Dir().x,0,0) * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 1 * speed, 0));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            dead = true;
        }
    }
}
