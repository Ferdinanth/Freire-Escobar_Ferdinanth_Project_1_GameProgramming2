using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    [Header("Global Vars")]
    public GameObject myPlayer;
    public float timer;
    public float timerLimit;
    public int score;

    [Header("NPC vars")]
    public GameObject collectible1;
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
    }

    // Update is called once per frame
    void Update()
    {
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
                if(timer > timerLimit)
                {
                    EnterFinale();
                }
        }
             
                 float x = Random.Range(spawnXBounds.x, spawnXBounds.y);
                 float y = Random.Range(spawnYBounds.x,spawnYBounds.y);
                 Vector3 targetPos = new Vector3(x, y, 0);
                
                if (spawnTimer > spawnInterval)
                {
                    Instantiate(collectible1, targetPos, Quaternion.identity);
                    spawnTimer = 0;
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
