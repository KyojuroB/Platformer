using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float delay = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Delay());

  
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    
}
