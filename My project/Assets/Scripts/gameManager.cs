using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    [Header("Global Vars")]
    public GameObject myPlayer;
    public float timer;
    public int score;

    [Header("NPC vars")]
    public GameObject collectible1;
    public float spawnInterval;
    public float spawnTimer;
    public Vector2 spawnXBounds;
    public Vector2 spawnYBounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        float x = Random.Range(spawnXBounds.x, spawnXBounds.y);
        float y = Random.Range(spawnYBounds.x,spawnYBounds.y);
        Vector3 targetPos = new Vector3(x, y, 0);
        if (spawnTimer > spawnInterval)
        {
            Instantiate(collectible1, targetPos, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
