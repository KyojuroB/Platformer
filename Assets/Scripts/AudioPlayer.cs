using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {

        int numberOfaudios = FindObjectsOfType<AudioPlayer>().Length;
        if (numberOfaudios > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }







    }
    private void FixedUpdate()
    {
        ////////////cheking to see if its the right scene or smt
        string currentSceneName = SceneManager.GetActiveScene().name;

        // levels
        List<string> scenesWithAudio = new List<string> { "Level1", "Level2", "Level4", "Level5", "Level6" };

        if (!scenesWithAudio.Contains(currentSceneName))
        {
            Destroy(gameObject);

        }
 
    }

}
