using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TmProHealthConverter : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       health = FindObjectOfType<GameSession>().GetHealth();
    }
}
