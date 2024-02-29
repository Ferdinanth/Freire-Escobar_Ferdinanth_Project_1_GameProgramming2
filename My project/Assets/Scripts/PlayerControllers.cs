using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControllers : MonoBehaviour
{
    public float speed = 1f;
    public SpriteRenderer mySprite;
    public int hitCount = 0;
    public float myHealth = 1000;
    Rigidbody2D myBody;

    Vector3 previousPos;
    Vector3 myDir;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(this.gameObject.transform.position ==  previousPos)
      {
         myHealth += 1 * Time.deltaTime;
      }
        previousPos = this.gameObject.transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Dir() * speed);
        myBody.AddForce(Dir(), ForceMode2D.Impulse);
    }
   
    public Vector3 Dir()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        myDir = new Vector3(x, y, 0);
        Debug.Log(myDir);
        return myDir;   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("other; " + collision.gameObject.name);
        Debug.Log("other tag: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            //myScore++;
        }
    }
    
    private IEnumerator itsBeenHit(float waitTime)
    {
        mySprite.color = Color.red;
        hitCount += 1;
        myHealth -= 25;
        yield return new WaitForSeconds(waitTime);
        mySprite.color = Color.white;
    }
}
