using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI timerText;
    public float timer;
    [SerializeField] bool trackDeath=true;

    DeathTracker deathTracker;

    private void Awake() {
        int numGameSession = FindObjectsOfType<GameManager>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        livesText.text = playerLives.ToString();
        
    }

    private void Update() {
        UpdateDeathStatus(); //checking the status of whether the player is alive or not.
        UpdateTimer(); //updating the timer in the top right corner as long as the player is alive
        if (trackDeath)
        {
        TakeLife(); // taking away a life if the player dies
        }
    }

    // public void ProcessPlayerDeath()
    // {
    //     if (playerLives > 1)
    //     {
    //         TakeLife();
    //     } 
    //     else
    //     {
    //         ResetGameSession();
    //     }
    // }

    private void TakeLife()
    {
        
        if (deathTracker.GetDeathStatus())
        {return;}
        else
        {    
            playerLives--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            livesText.text = playerLives.ToString();
            deathTracker.ResetDeathStatus();
        }
    }

    // NOT CURRENTLY USED IN THE CODE. 
    // This is the beginning of a reset function to reset the level to either a checkpoint 
    // or the beginning if you lose all 3 lives

    // private void ResetGameSession()
    // {
    //     Debug.Log("You have reset the game");
    //     SceneManager.LoadScene(0);
    // }

 
    private void UpdateTimer()
    {
        if (playerLives>-1) //checking to make sure you are alive. If you die the timer will stop updating so we can pull the time you died.
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString();
            if (timerText.text.Length > 4)
            {
                timerText.text = timerText.text.Substring(0,4);
            }
        }
    }

    private void UpdateDeathStatus()
    {
       if (trackDeath)
       {
        deathTracker = FindObjectOfType<DeathTracker>();
       }
    }

}
