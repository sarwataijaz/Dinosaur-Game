using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel.Design.Serialization;


[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    private AudioSource audioSource1;
 
    public float volume;
    public float gameSpeed { get; private set; }
    public float initialSpeed = 5f;

    public Text score;
    public Text highScore;

    public int playerScore;
    public int hiScore;
    private int temp = 0;

    public DinoScript player;
    private Spawner spawner;
    public GameObject scorePanel;
    public GameObject gameOverScreen;
    public GameObject hiScoreBeep;
   
    // public float increaseBy = 0.1f;
    public static GameManager instance { get; private set; } // this will have a public getter that everyone can access
                                                             // while a private setter that only it can assign   
   

    public void addScore(int add)
    {
       
        playerScore += add;
        score.text = playerScore.ToString();
        
        if (hiScoreBeep != null && temp < 1) // so it only executes once
        {
            if (playerScore > hiScore)
            {
                hiScoreBeep.gameObject.SetActive(true);
                temp++;
            }
           
        }
    }

    private void Update()
    {

        
    }
    private void Awake()
    {

        if (instance == null)
        {
            //no instance means we will assign the instance
            instance = this;
        }
        else
        {
            // destroy the unknown one immediately
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<DinoScript>();
        spawner = FindObjectOfType<Spawner>();
        audioSource1 = GetComponent<AudioSource>();
       
        newGame();

    }


    public void gameOver()
    {
        gameSpeed = 0;

        audioSource1.volume = volume;
        audioSource1.Play();
        
        spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        scorePanel.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);

    }
    public void newGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>(); // for more than one object -> objects

        foreach (var obs in obstacles)
        {
            Destroy(obs.gameObject);
        }


        if(playerScore > hiScore)
        {
            hiScore = playerScore;
        }

        playerScore = 0;
        score.text = 0.ToString();
        highScore.text = hiScore.ToString();

        scorePanel.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);  

        gameSpeed = initialSpeed;
    }


}