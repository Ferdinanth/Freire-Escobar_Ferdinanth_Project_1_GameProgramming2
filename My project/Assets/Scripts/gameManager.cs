using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    [Header("Global Vars")]
    public bool isBird;
    public GameObject myPlayer;
    public float timer;
    public float timerLimit;
    public int score;
    PlayerControllers myController;
    birdController myBird;

    [Header("NPC vars")]
    public GameObject Collectible;
    public float spawnInterval;
    public float spawnTimer;
    public Vector2 spawnXBounds;
    public Vector2 spawnYBounds;

    [Header("UI/UX Vars")]
    public TextMeshProUGUI TitleText;

    //states the first instance of the subclass enum-GameState
    public enum GameState
    {
        GAMESTART, PLAYING, GAMEOVER
    };
        
    public GameState myGameState;

    // Start is called before the first frame update
    void Start()
    {
        myGameState = GameState.GAMESTART;
        myPlayer.SetActive(false);
        if (isBird) { myBird = myPlayer.GetComponent<birdController>(); }
        else { myController = myPlayer.GetComponent<PlayerControllers>(); }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBird) 
        { 
            if (myController.myHealth < 0)
            {
                EnterFinale();
            }
        }

        switch (myGameState)
        {
            case GameState.GAMESTART:
                if (Input.GetKey(KeyCode.Space))
                {
                    EnterPlaying();
                }
                break;

            case GameState.PLAYING:
                #region PLAYING_code
                timer += Time.deltaTime;
                spawnTimer += Time.deltaTime;

                if (timer > timerLimit)
                {
                    EnterFinale();
                }

                float x = Random.Range(spawnXBounds.x, spawnXBounds.y);
                float y = Random.Range(spawnYBounds.x, spawnYBounds.y);
                Vector3 targetPos = new Vector3(x, y, 0);

                if (spawnTimer > spawnInterval)
                {
                    spawnTimer = 0;
                    Debug.Log("spawnTimer: " + spawnTimer);
                    GameObject newObj = Instantiate(Collectible, targetPos, Quaternion.identity);
                    if(!isBird) { newObj.GetComponent<enemyController>().myPlayer = myPlayer; }
                    
                }
                #endregion
                break;

            case GameState.GAMEOVER:
                if (Input.GetKey(KeyCode.Space))
                {
                    EnterPlaying();
                }
                break;
        }
    }
    void EnterPlaying()
    {
        GameObject[] enemyObj = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemyObj.Length; i += 1)
        {
            Destroy(enemyObj[i]);
        }

        timer = 0f;
        spawnTimer = 0f;
        myGameState = GameState.PLAYING;
        if (!isBird) { myController.myHealth = 1000; }
        myPlayer.SetActive(true);
        TitleText.enabled = false;

    }
    public void EnterFinale()
    {
        myGameState = GameState.GAMEOVER;
        myPlayer.SetActive(false);
        TitleText.enabled = true;
        TitleText.text = "GAME OVER. Press [Space] to restart";
    }
}