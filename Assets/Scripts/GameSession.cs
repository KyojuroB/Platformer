using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject currentCheckpoint = null;
    [SerializeField] GameObject player;
    AsyncOperation asyncLoad;

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


        
    }
    public int GetHealth()
    {
        return playerLives;
    }

    public void SetHealth(int ammount)
    { 
        playerLives = ammount;
    }
    public void DoDamage()
    {
        if (playerLives > 1)
        {
            StartCoroutine(TakeLives());  
        }
        else 
        {
            ResetGameSession();
        }
    }

    private IEnumerator TakeLives()
    {
        playerLives--;
       // FindObjectOfType<HealthBar>().remove();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        asyncLoad = SceneManager.LoadSceneAsync(currentSceneIndex, LoadSceneMode.Single);
        //   SceneManager.LoadScene(currentSceneIndex);
        while (!asyncLoad.isDone)
        {
            print("Loading the Scene");
            yield return null;
        }
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (currentCheckpoint != null && player != null)
        {
        
            player.transform.position = new Vector2(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y + 0.3f);
             Debug.Log("checkpointWorked");
        }

    }
    private void FixedUpdate()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // levels
        List<string> scenesWithsettings = new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6" };

        if (!scenesWithsettings.Contains(currentSceneName))
        {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        if (scenesWithsettings.Contains(currentSceneName))
        {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        }
    }

    private void ResetGameSession()
    {
        
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene("Loss");
        Destroy(gameObject);
    }
    public void SetCheckpoint(GameObject obj)
    {
        currentCheckpoint = obj;
    }
}
