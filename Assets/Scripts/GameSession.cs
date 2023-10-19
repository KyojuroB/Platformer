using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TMP_Text scoreText;



    private void Start()
    {

       scoreText.text = score.ToString();

    }
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
;
        
    }
    public int GetHealth()
    {
        return playerLives;
    }
    public void DoDamage()
    {
        if (playerLives > 1)
        {
            TakeLives();
        }
        else 
        {
            ResetGameSession();
        }
    }

    private void TakeLives()
    {
        playerLives--;
        FindObjectOfType<HealthBar>().remove();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);

    }

    private void ResetGameSession()
    {
        
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
