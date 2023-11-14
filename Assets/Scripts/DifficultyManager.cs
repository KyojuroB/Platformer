using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Easy()
    { 
        FindObjectOfType<GameSession>().SetHealth(4);
    }

    public void Medium()
    {
        FindObjectOfType<GameSession>().SetHealth(3);
    }
    public void Hard()
    {
        FindObjectOfType<GameSession>().SetHealth(1);
    }


}
